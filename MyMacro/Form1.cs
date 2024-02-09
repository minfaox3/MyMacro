using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using WindowsInput;
using System.Diagnostics;
using MyMacro.Utility;
using System.Security.Principal;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace MyMacro
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private extern static bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        enum KeyStroke
        {
            Down = 0,
            Press = 1,
            Up = 2
        }

        enum ActionKind
        {
            Key = 0,
            Mouse = 1,
            Click = 2,
            Scroll = 3,
            Delay = 4,
            Text = 5
        }

        enum ClickButton
        {
            Left = 0,
            Middle = 1,
            Right = 2
        }

        enum ClickMotion
        {
            Click = 0,
            DoubleClick = 1,
            Down = 2,
            Up = 3
        }

        enum ScrollDirection
        {
            Horizontal = 0,
            Vertical = 1
        }

        struct KeyAction
        {
            public KeyStroke KeyStroke;
            public WindowsInput.Native.VirtualKeyCode SelectedVirtualKeyCode;

            public KeyAction(KeyStroke keyStroke, WindowsInput.Native.VirtualKeyCode selectedVirtualKeyCode)
            {
                KeyStroke = keyStroke;
                SelectedVirtualKeyCode = selectedVirtualKeyCode;
            }
        }

        struct MouseAction
        {
            public int X;
            public int Y;

            public MouseAction(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        struct ClickAction
        {
            public ClickButton clickButton;
            public ClickMotion clickMotion;

            public ClickAction(ClickButton button, ClickMotion motion)
            {
                clickButton = button;
                clickMotion = motion;
            }
        }

        struct ScrollAction
        {
            public ScrollDirection scrollDirection;
            public int scrollAmount;

            public ScrollAction(ScrollDirection direction, int amount)
            {
                scrollDirection = direction;
                scrollAmount = amount;
            }
        }

        struct DelayAction
        {
            public int MSec;

            public DelayAction(int msec)
            {
                MSec = msec;
            }
        }

        struct TextAction
        {
            public string Text;

            public TextAction(string text)
            {
                Text = text;
            }
        }


        struct Action
        {
            public ActionKind kind;
            public KeyAction keyAction;
            public MouseAction mouseAction;
            public DelayAction delayAction;
            public TextAction textAction;
            public ClickAction clickAction;
            public ScrollAction scrollAction;
            public string description;

            public Action(KeyAction action)
            {
                kind = ActionKind.Key;
                keyAction = action;
                description = keyAction.KeyStroke.ToString() + " " + keyAction.SelectedVirtualKeyCode.ToString() + " key.";
            }

            public Action(MouseAction action)
            {
                kind = ActionKind.Mouse;
                mouseAction = action;
                description = "Move mouse to (" + mouseAction.X + ", " + mouseAction.Y + ").";
            }

            public Action(DelayAction action)
            {
                kind = ActionKind.Delay;
                delayAction = action;
                description = "Delay for " + delayAction.MSec + " msec.";
            }

            public Action(TextAction action)
            {
                kind = ActionKind.Text;
                textAction = action;
                description = "Input \"" + textAction.Text + "\".";
            }

            public Action(ClickAction action)
            {
                kind = ActionKind.Click;
                clickAction = action;
                description = action.clickMotion.ToString() + " " + action.clickButton.ToString() + ".";
            }

            public Action(ScrollAction action)
            {
                kind = ActionKind.Scroll;
                scrollAction = action;
                description = "Scroll " + action.scrollDirection.ToString() + " " + action.scrollAmount + ".";
            }
        }

        private class ActionData
        {
            public string Order { get; set; }
            private Action pAction;

            public ActionData(Action action)
            {
                pAction = action;
                Order = action.description;
            }

            public Action GetAction()
            {
                return pAction;
            }
        }



        /*
         * Variables
         */

        private (String, IntPtr, int, int) selectedWindow;

        private List<(String, IntPtr, int, int)> windowData = new List<(String, IntPtr, int, int)>();

        private BindingList<ActionData> actionData = new BindingList<ActionData>();

        private WindowsInput.Native.VirtualKeyCode terminateKey;

        private HookProc mouseHookProc;

        private IntPtr mouseHookId;

        private HookProc keyboardHookProc;

        private IntPtr keyboardHookId;

        private bool printOtherWindow = false;

        private bool terminate = false;

        private bool loop = false;

        private int loopSpan;

        /*
         * Functions
         */

        public Form1()
        {
            InitializeComponent();
        }

        private bool EnumWindowCallBack(IntPtr hWnd, IntPtr lparam)
        {
            int textLen = GetWindowTextLength(hWnd);
            if (0 < textLen)
            {
                StringBuilder tsb = new StringBuilder(textLen + 1);
                GetWindowText(hWnd, tsb, tsb.Capacity);

                StringBuilder csb = new StringBuilder(256);
                GetClassName(hWnd, csb, csb.Capacity);

                if (csb.ToString() == "Progman") return true;
                if (!IsWindowVisible(hWnd)) return true;
                if (IsIconic(hWnd)) return true;

                RECT winRect = new RECT();
                GetWindowRect(hWnd, ref winRect);
                if (winRect.top == winRect.bottom || winRect.right == winRect.left) return true;
                windowData.Add((tsb.ToString(), hWnd, winRect.right - winRect.left, winRect.bottom - winRect.top));
            }
            return true;
        }

        private void GetWindowList()
        {
            windowData.Clear();
            EnumWindows(new EnumWindowsDelegate(EnumWindowCallBack), IntPtr.Zero);
        }

        private void EscalatePrivilege()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Application.ExecutablePath;
            processStartInfo.UseShellExecute = true;
            processStartInfo.Verb = "runas";

            try
            {
                Process.Start(processStartInfo);
                Close();
            }
            catch
            {
                SetStatusText("Failed to escalate privilege.");
            }
        }

        private Bitmap GetWindowImage(int index)
        {
            Bitmap img = new Bitmap(windowData[index].Item3, windowData[index].Item4);
            Graphics memg = Graphics.FromImage(img);
            IntPtr dc = memg.GetHdc();
            if (PrintWindow(windowData[index].Item2, dc, 0x00000002))
            {
                memg.ReleaseHdc(dc);
                memg.Dispose();
                printOtherWindow = true;
            }
            else
            {
                memg.ReleaseHdc(dc);
                memg.Dispose();
                printOtherWindow = false;
                EscalatePrivilege();
            }
            return img;
        }

        private void DisableControl()
        {
            comboBoxKeyStroke.Enabled = false;
            comboBoxMacroKey.Enabled = false;
            comboBoxTerminateKey.Enabled = false;
            comboBoxWindowNames.Enabled = false;
            comboBoxClickButton.Enabled = false;
            comboBoxClickMotion.Enabled = false;
            comboBoxScrollDirection.Enabled = false;
            textBoxMouseX.Enabled = false;
            textBoxMouseY.Enabled = false;
            textBoxMacroText.Enabled = false;
            textBoxDelayMSec.Enabled = false;
            textBoxDelaySec.Enabled = false;
            textBoxScrollAmount.Enabled = false;
            textBoxLoopSpan.Enabled = false;
            buttonAddClickMacro.Enabled = false;
            buttonAddDelayMSec.Enabled = false;
            buttonAddDelaySec.Enabled = false;
            buttonAddKeyMacro.Enabled = false;
            buttonAddTextMacro.Enabled = false;
            buttonAddMouseMacro.Enabled = false;
            buttonAddScroll.Enabled = false;
            buttonSelectWindow.Enabled = false;
            buttonWCUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
            buttonPlay.Enabled = false;
            checkBoxLoop.Enabled = false;
            dataGridViewActions.Enabled = false;
        }

        private void EnableControl()
        {
            comboBoxKeyStroke.Enabled = true;
            comboBoxMacroKey.Enabled = true;
            comboBoxTerminateKey.Enabled = true;
            comboBoxWindowNames.Enabled = true;
            comboBoxClickButton.Enabled = true;
            comboBoxClickMotion.Enabled = true;
            comboBoxScrollDirection.Enabled = true;
            textBoxMouseX.Enabled = true;
            textBoxMouseY.Enabled = true;
            textBoxMacroText.Enabled = true;
            textBoxDelayMSec.Enabled = true;
            textBoxDelaySec.Enabled = true;
            textBoxScrollAmount.Enabled = true;
            textBoxLoopSpan.Enabled = true;
            buttonAddClickMacro.Enabled = true;
            buttonAddDelayMSec.Enabled = true;
            buttonAddDelaySec.Enabled = true;
            buttonAddKeyMacro.Enabled = true;
            buttonAddTextMacro.Enabled = true;
            buttonAddMouseMacro.Enabled = true;
            buttonAddScroll.Enabled = true;
            buttonSelectWindow.Enabled = true;
            buttonWCUpdate.Enabled = true;
            buttonDelete.Enabled = true;
            buttonUp.Enabled = true;
            buttonDown.Enabled = true;
            buttonPlay.Enabled = true;
            checkBoxLoop.Enabled = true;
            dataGridViewActions.Enabled = true;
        }

        private IntPtr KeyboardHookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                tagKBDLLHOOKSTRUCT tagKbdllhookstruct = (tagKBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(tagKBDLLHOOKSTRUCT));
                if (wParam == (IntPtr)WindowMessage.WM_KEYDOWN)
                {
                    if ((int)terminateKey == tagKbdllhookstruct.vkCode)
                    {
                        terminate = true;
                    }
                }
                else if (wParam == (IntPtr)WindowMessage.WM_KEYUP)
                {
                    //
                }
                else if (wParam == (IntPtr)WindowMessage.WM_SYSKEYDOWN)
                {
                    if ((int)terminateKey == tagKbdllhookstruct.vkCode)
                    {
                        terminate = true;
                    }
                }
                else if (wParam == (IntPtr)WindowMessage.WM_SYSKEYUP)
                {
                    //
                }
            }
            return CallNextHookEx(keyboardHookId, nCode, wParam, lParam);
        }

        private IntPtr MouseHookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WindowMessage.WM_MOUSEMOVE)
            {
                MSLLHOOKSTRUCT msllhookstruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                SetStatusText("X:" + msllhookstruct.pt.x + " Y:" + msllhookstruct.pt.y);
            }
            return CallNextHookEx(mouseHookId, nCode, wParam, lParam);
        }

        private bool CheckPrivilege()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckPrivilege())
            {
                Text = "MyMacro (Admin)";
            }

            buttonPlay.Enabled = false;

            GetWindowList();
            comboBoxWindowNames.Items.Clear();
            foreach (var windowValueTuple in windowData)
            {
                comboBoxWindowNames.Items.Add(windowValueTuple.Item1);
            }

            comboBoxKeyStroke.DataSource = Enum.GetValues(typeof(KeyStroke));
            comboBoxMacroKey.DataSource = Enum.GetValues(typeof(WindowsInput.Native.VirtualKeyCode));
            comboBoxTerminateKey.DataSource = Enum.GetValues(typeof(WindowsInput.Native.VirtualKeyCode));

            comboBoxClickButton.DataSource = Enum.GetValues(typeof(ClickButton));
            comboBoxClickMotion.DataSource = Enum.GetValues(typeof(ClickMotion));
            comboBoxScrollDirection.DataSource = Enum.GetValues(typeof(ScrollDirection));

            dataGridViewActions.DataSource = actionData;

            mouseHookProc = MouseHookProcedure;
            mouseHookId = SetWindowsHookEx(WindowsHook.WH_MOUSE_LL, mouseHookProc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mouseHookId != IntPtr.Zero) UnhookWindowsHookEx(mouseHookId);
            if (keyboardHookId != IntPtr.Zero) UnhookWindowsHookEx(keyboardHookId);
        }

        private void buttonWCUpdate_Click(object sender, EventArgs e)
        {
            GetWindowList();
            comboBoxWindowNames.Items.Clear();
            foreach (var windowValueTuple in windowData)
            {
                comboBoxWindowNames.Items.Add(windowValueTuple.Item1);
            }
        }

        private void buttonSelectWindow_Click(object sender, EventArgs e)
        {
            if (comboBoxWindowNames.SelectedIndex < windowData.Count && comboBoxWindowNames.SelectedIndex >= 0)
            {
                comboBoxWindowNames.Enabled = false;

                pictureBoxWindowThumb.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxWindowThumb.Image = GetWindowImage(comboBoxWindowNames.SelectedIndex);

                if (!printOtherWindow)
                {
                    comboBoxWindowNames.Enabled = true;
                    return;
                }

                selectedWindow = windowData[comboBoxWindowNames.SelectedIndex];
                buttonPlay.Enabled = true;
                comboBoxWindowNames.Enabled = true;
            }
        }

        private void buttonAddKeyMacro_Click(object sender, EventArgs e)
        {
            KeyStroke keyStroke;
            WindowsInput.Native.VirtualKeyCode virtualKeyCode;
            if(Enum.TryParse(comboBoxKeyStroke.SelectedValue.ToString(), out keyStroke) && Enum.TryParse(comboBoxMacroKey.SelectedValue.ToString(), out virtualKeyCode))
            {
                actionData.Add(new ActionData(new Action(new KeyAction(keyStroke, virtualKeyCode))));
            }
        }

        private void buttonAddMouseMacro_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if (int.TryParse(textBoxMouseX.Text, out x) && int.TryParse(textBoxMouseY.Text, out y))
            {
                actionData.Add(new ActionData(new Action(new MouseAction(x, y))));
            }

        }

        private void buttonAddTextMacro_Click(object sender, EventArgs e)
        {
            actionData.Add(new ActionData(new Action(new TextAction(textBoxMacroText.Text))));
        }

        private void buttonAddDelayMSec_Click(object sender, EventArgs e)
        {
            int delay;
            if (int.TryParse(textBoxDelayMSec.Text, out delay))
            {
                actionData.Add(new ActionData(new Action(new DelayAction(delay))));
            }
        }

        private void buttonAddDelaySec_Click(object sender, EventArgs e)
        {
            int delay;
            if (int.TryParse(textBoxDelaySec.Text + "000", out delay))
            {
                actionData.Add(new ActionData(new Action(new DelayAction(delay))));
            }
        }

        private void buttonAddClickMacro_Click(object sender, EventArgs e)
        {
            ClickButton clickButton;
            ClickMotion clickMotion;
            if(Enum.TryParse(comboBoxClickButton.SelectedValue.ToString(), out clickButton) && Enum.TryParse(comboBoxClickMotion.SelectedValue.ToString(), out clickMotion))
            {
                actionData.Add(new ActionData(new Action(new ClickAction(clickButton, clickMotion))));
            }
        }

        private void buttonAddScroll_Click(object sender, EventArgs e)
        {
            ScrollDirection scrollDirection;
            int scrollAmount;
            if(Enum.TryParse(comboBoxScrollDirection.SelectedValue.ToString(), out scrollDirection) && int.TryParse(textBoxScrollAmount.Text, out scrollAmount))
            {
                actionData.Add(new ActionData(new Action(new ScrollAction(scrollDirection, scrollAmount))));
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewActions.CurrentCell != null)
            {
                actionData.RemoveAt(dataGridViewActions.CurrentCell.RowIndex);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewActions.CurrentCell != null && dataGridViewActions.CurrentCell.RowIndex > 0)
            {
                (actionData[dataGridViewActions.CurrentCell.RowIndex], actionData[dataGridViewActions.CurrentCell.RowIndex - 1]) = (actionData[dataGridViewActions.CurrentCell.RowIndex - 1], actionData[dataGridViewActions.CurrentCell.RowIndex]);
                dataGridViewActions.CurrentCell = dataGridViewActions[0, dataGridViewActions.CurrentCell.RowIndex - 1];
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewActions.CurrentCell != null && dataGridViewActions.CurrentCell.RowIndex < actionData.Count - 1)
            {
                (actionData[dataGridViewActions.CurrentCell.RowIndex], actionData[dataGridViewActions.CurrentCell.RowIndex + 1]) = (actionData[dataGridViewActions.CurrentCell.RowIndex + 1], actionData[dataGridViewActions.CurrentCell.RowIndex]);
                dataGridViewActions.CurrentCell = dataGridViewActions[0, dataGridViewActions.CurrentCell.RowIndex + 1];
            }
        }

        private void KeyPress(IntPtr hwnd, InputSimulator inputSimulator, WindowsInput.Native.VirtualKeyCode virtualKeyCode)
        {
            if (GetForegroundWindow() == hwnd)
            {
                inputSimulator.Keyboard.KeyPress(virtualKeyCode);
            }
        }

        private void KeyUp(IntPtr hwnd, InputSimulator inputSimulator, WindowsInput.Native.VirtualKeyCode virtualKeyCode)
        {
            if (GetForegroundWindow() == hwnd)
            {
                inputSimulator.Keyboard.KeyUp(virtualKeyCode);
            }
        }

        private void KeyDown(IntPtr hwnd, InputSimulator inputSimulator, WindowsInput.Native.VirtualKeyCode virtualKeyCode)
        {
            if (GetForegroundWindow() == hwnd)
            {
                inputSimulator.Keyboard.KeyDown(virtualKeyCode);
            }
        }

        private void TextEntry(IntPtr hwnd, InputSimulator inputSimulator, string text)
        {
            if (GetForegroundWindow() == hwnd)
            {
                inputSimulator.Keyboard.TextEntry(text);
            }

        }

        private void MoveMouseTo(IntPtr hwnd, InputSimulator inputSimulator, int x, int y)
        {
            if (GetForegroundWindow() == hwnd)
            {
                double X = x * 65535 / SystemInformation.VirtualScreen.Width;
                double Y = y * 65535 / SystemInformation.VirtualScreen.Height;
                inputSimulator.Mouse.MoveMouseToPositionOnVirtualDesktop(X, Y);
            }

        }

        private void ButtonUp(IntPtr hwnd, InputSimulator inputSimulator, ClickButton button)
        {
            if (GetForegroundWindow() == hwnd)
            {
                switch (button)
                {
                    case ClickButton.Left:
                        inputSimulator.Mouse.LeftButtonUp();
                        break;
                    case ClickButton.Right:
                        inputSimulator.Mouse.RightButtonUp();
                        break;
                    case ClickButton.Middle:
                        inputSimulator.Mouse.XButtonUp(2);
                        break;
                    default:
                        SetStatusText("Unknown action detected.");
                        break;
                }
            }
        }
        private void ButtonDown(IntPtr hwnd, InputSimulator inputSimulator, ClickButton button)
        {
            if (GetForegroundWindow() == hwnd)
            {
                switch (button)
                {
                    case ClickButton.Left:
                        inputSimulator.Mouse.LeftButtonDown();
                        break;
                    case ClickButton.Right:
                        inputSimulator.Mouse.RightButtonDown();
                        break;
                    case ClickButton.Middle:
                        inputSimulator.Mouse.XButtonDown(2);
                        break;
                    default:
                        SetStatusText("Unknown action detected.");
                        break;
                }
            }
        }
        private void ButtonClick(IntPtr hwnd, InputSimulator inputSimulator, ClickButton button)
        {
            if (GetForegroundWindow() == hwnd)
            {
                switch (button)
                {
                    case ClickButton.Left:
                        inputSimulator.Mouse.LeftButtonClick();
                        break;
                    case ClickButton.Right:
                        inputSimulator.Mouse.RightButtonClick();
                        break;
                    case ClickButton.Middle:
                        inputSimulator.Mouse.XButtonClick(2);
                        break;
                    default:
                        SetStatusText("Unknown action detected.");
                        break;
                }
            }
        }

        private void ButtonDoubleClick(IntPtr hwnd, InputSimulator inputSimulator, ClickButton button)
        {
            if (GetForegroundWindow() == hwnd)
            {
                switch (button)
                {
                    case ClickButton.Left:
                        inputSimulator.Mouse.LeftButtonDoubleClick();
                        break;
                    case ClickButton.Right:
                        inputSimulator.Mouse.RightButtonDoubleClick();
                        break;
                    case ClickButton.Middle:
                        inputSimulator.Mouse.XButtonDoubleClick(2);
                        break;
                    default:
                        SetStatusText("Unknown action detected.");
                        break;
                }
            }
        }


        private void HorizontalScroll(IntPtr hwnd, InputSimulator inputSimulator, int scrollAmount)
        {
            if (GetForegroundWindow() == hwnd)
            {
                inputSimulator.Mouse.HorizontalScroll(scrollAmount);
            }
        }

        private void VerticalScroll(IntPtr hwnd, InputSimulator inputSimulator, int scrollAmount)
        {
            if (GetForegroundWindow() == hwnd)
            {
                inputSimulator.Mouse.VerticalScroll(scrollAmount);
            }
        }

        private void SetStatusText(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                System.Action setText = delegate
                {
                    SetStatusText(text);
                };
                statusStrip.Invoke(setText);
            }
            else
            {
                toolStripStatusLabel.Text = text;
            }
        }

        private async void RunAction()
        {
            await Task.Run(async () =>
            {
                var inputSimulator = new InputSimulator();
                SetForegroundWindow(selectedWindow.Item2);

                if (loop)
                {
                    while (true)
                    {
                        foreach (var vActionData in actionData)
                        {
                            var vAction = vActionData.GetAction();
                            SetStatusText(vAction.description);
                            switch (vAction.kind)
                            {
                                case ActionKind.Key:
                                    switch (vAction.keyAction.KeyStroke)
                                    {
                                        case KeyStroke.Down:
                                            KeyDown(selectedWindow.Item2, inputSimulator, vAction.keyAction.SelectedVirtualKeyCode);
                                            break;
                                        case KeyStroke.Press:
                                            KeyPress(selectedWindow.Item2, inputSimulator, vAction.keyAction.SelectedVirtualKeyCode);
                                            break;
                                        case KeyStroke.Up:
                                            KeyUp(selectedWindow.Item2, inputSimulator, vAction.keyAction.SelectedVirtualKeyCode);
                                            break;
                                        default:
                                            SetStatusText("Unknown action detected.");
                                            break;
                                    }
                                    break;
                                case ActionKind.Mouse:
                                    MoveMouseTo(selectedWindow.Item2, inputSimulator, vAction.mouseAction.X, vAction.mouseAction.Y);
                                    break;
                                case ActionKind.Click:
                                    switch (vAction.clickAction.clickMotion)
                                    {
                                        case ClickMotion.Click:
                                            ButtonClick(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                            break;
                                        case ClickMotion.DoubleClick:
                                            ButtonDoubleClick(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                            break;
                                        case ClickMotion.Up:
                                            ButtonUp(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                            break;
                                        case ClickMotion.Down:
                                            ButtonDown(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                            break;
                                        default:
                                            SetStatusText("Unknown action detected.");
                                            break;
                                    }
                                    break;
                                case ActionKind.Scroll:
                                    switch (vAction.scrollAction.scrollDirection)
                                    {
                                        case ScrollDirection.Horizontal:
                                            HorizontalScroll(selectedWindow.Item2, inputSimulator, vAction.scrollAction.scrollAmount);
                                            break;
                                        case ScrollDirection.Vertical:
                                            VerticalScroll(selectedWindow.Item2, inputSimulator, vAction.scrollAction.scrollAmount);
                                            break;
                                        default:
                                            SetStatusText("Unknown action detected.");
                                            break;
                                    }
                                    break;
                                case ActionKind.Delay:
                                    await Task.Delay(vAction.delayAction.MSec);
                                    break;
                                case ActionKind.Text:
                                    TextEntry(selectedWindow.Item2, inputSimulator, vAction.textAction.Text);
                                    break;
                                default:
                                    SetStatusText("Unknown action detected.");
                                    break;
                            }
                            if (terminate) break;
                        }
                        if (terminate) break;
                        await Task.Delay(loopSpan);
                    }
                }
                else
                {
                    foreach (var vActionData in actionData)
                    {
                        var vAction = vActionData.GetAction();
                        SetStatusText(vAction.description);
                        switch (vAction.kind)
                        {
                            case ActionKind.Key:
                                switch (vAction.keyAction.KeyStroke)
                                {
                                    case KeyStroke.Down:
                                        KeyDown(selectedWindow.Item2, inputSimulator, vAction.keyAction.SelectedVirtualKeyCode);
                                        break;
                                    case KeyStroke.Press:
                                        KeyPress(selectedWindow.Item2, inputSimulator, vAction.keyAction.SelectedVirtualKeyCode);
                                        break;
                                    case KeyStroke.Up:
                                        KeyUp(selectedWindow.Item2, inputSimulator, vAction.keyAction.SelectedVirtualKeyCode);
                                        break;
                                    default:
                                        SetStatusText("Unknown action detected.");
                                        break;
                                }
                                break;
                            case ActionKind.Mouse:
                                MoveMouseTo(selectedWindow.Item2, inputSimulator, vAction.mouseAction.X, vAction.mouseAction.Y);
                                break;
                            case ActionKind.Click:
                                switch (vAction.clickAction.clickMotion)
                                {
                                    case ClickMotion.Click:
                                        ButtonClick(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                        break;
                                    case ClickMotion.DoubleClick:
                                        ButtonDoubleClick(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                        break;
                                    case ClickMotion.Up:
                                        ButtonUp(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                        break;
                                    case ClickMotion.Down:
                                        ButtonDown(selectedWindow.Item2, inputSimulator, vAction.clickAction.clickButton);
                                        break;
                                    default:
                                        SetStatusText("Unknown action detected.");
                                        break;
                                }
                                break;
                            case ActionKind.Scroll:
                                switch (vAction.scrollAction.scrollDirection)
                                {
                                    case ScrollDirection.Horizontal:
                                        HorizontalScroll(selectedWindow.Item2, inputSimulator, vAction.scrollAction.scrollAmount);
                                        break;
                                    case ScrollDirection.Vertical:
                                        VerticalScroll(selectedWindow.Item2, inputSimulator, vAction.scrollAction.scrollAmount);
                                        break;
                                    default:
                                        SetStatusText("Unknown action detected.");
                                        break;
                                }
                                break;
                            case ActionKind.Delay:
                                await Task.Delay(vAction.delayAction.MSec);
                                break;
                            case ActionKind.Text:
                                TextEntry(selectedWindow.Item2, inputSimulator, vAction.textAction.Text);
                                break;
                            default:
                                SetStatusText("Unknown action detected.");
                                break;
                        }
                        if (terminate) break;
                    }
                }
            });
            Show();
            if (keyboardHookId != IntPtr.Zero) UnhookWindowsHookEx(keyboardHookId);
            mouseHookId = SetWindowsHookEx(WindowsHook.WH_MOUSE_LL, mouseHookProc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
            if (terminate)
            {
                SetStatusText("Action terminated.");
            }
            else
            {
                SetStatusText("Action complete.");
            }
            EnableControl();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            DisableControl();
            WindowsInput.Native.VirtualKeyCode virtualKeyCode;
            Enum.TryParse(comboBoxTerminateKey.SelectedValue.ToString(), out virtualKeyCode);
            terminateKey = virtualKeyCode;
            loop = checkBoxLoop.Checked;
            int.TryParse(textBoxLoopSpan.Text, out loopSpan);
            if (mouseHookId != IntPtr.Zero) UnhookWindowsHookEx(mouseHookId);
            keyboardHookProc = KeyboardHookProcedure;
            keyboardHookId = SetWindowsHookEx(WindowsHook.WH_KEYBOARD_LL, keyboardHookProc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
            terminate = false;
            RunAction();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mouseHookId != IntPtr.Zero) UnhookWindowsHookEx(mouseHookId);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Macro Action Data file(*.mad)|*.mad";
            openFileDialog.Title = "Import MAD file";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader inputFile = new StreamReader(openFileDialog.FileName, true))
                {
                    try
                    {
                        List<Action> actions = JsonConvert.DeserializeObject<List<Action>>(inputFile.ReadToEnd());
                        actionData.Clear();
                        foreach (Action action in actions)
                        {
                            actionData.Add(new ActionData(action));
                        }
                    }
                    catch
                    {
                        SetStatusText("Failed to import file.");
                    }
                }
            }

            mouseHookId = SetWindowsHookEx(WindowsHook.WH_MOUSE_LL, mouseHookProc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mouseHookId != IntPtr.Zero) UnhookWindowsHookEx(mouseHookId);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "newfile.mad";
            saveFileDialog.Filter = "Macro Action Data file(*.mad)|*.mad";
            saveFileDialog.Title = "Export MAD file";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckPathExists = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName, false))
                {
                    List<Action> actions = new List<Action>();
                    foreach(ActionData actionData in actionData) {
                        actions.Add(actionData.GetAction());
                    }
                    outputFile.WriteLine(JsonConvert.SerializeObject(actions));
                }
            }
            else
            {
                SetStatusText("Failed to export mad file.");
            }

            mouseHookId = SetWindowsHookEx(WindowsHook.WH_MOUSE_LL, mouseHookProc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
        }
    }
}
