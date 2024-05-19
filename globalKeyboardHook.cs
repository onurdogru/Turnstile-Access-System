// Decompiled with JetBrains decompiler
// Type: Utilities.globalKeyboardHook
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Utilities
{
  internal class globalKeyboardHook
  {
    public List<Keys> HookedKeys = new List<Keys>();
    private IntPtr hhook = IntPtr.Zero;
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 256;
    private const int WM_KEYUP = 257;
    private const int WM_SYSKEYDOWN = 260;
    private const int WM_SYSKEYUP = 261;

    public event KeyEventHandler KeyDown;

    public event KeyEventHandler KeyUp;

    public globalKeyboardHook()
    {
      this.hook();
    }

    ~globalKeyboardHook()
    {
      this.unhook();
    }

    public void hook()
    {
      this.hhook = globalKeyboardHook.SetWindowsHookEx(13, new globalKeyboardHook.keyboardHookProc(this.hookProc), globalKeyboardHook.LoadLibrary("User32"), 0U);
    }

    public void unhook()
    {
      globalKeyboardHook.UnhookWindowsHookEx(this.hhook);
    }

    public int hookProc(int code, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam)
    {
      if (code >= 0)
      {
        Keys vkCode = (Keys) lParam.vkCode;
        if (this.HookedKeys.Contains(vkCode))
        {
          KeyEventArgs e = new KeyEventArgs(vkCode);
          if ((wParam == 256 || wParam == 260) && this.KeyDown != null)
            this.KeyDown((object) this, e);
          else if ((wParam == 257 || wParam == 261) && this.KeyUp != null)
            this.KeyUp((object) this, e);
          if (e.Handled)
            return 1;
        }
      }
      return globalKeyboardHook.CallNextHookEx(this.hhook, code, wParam, ref lParam);
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SetWindowsHookEx(
      int idHook,
      globalKeyboardHook.keyboardHookProc callback,
      IntPtr hInstance,
      uint threadId);

    [DllImport("user32.dll")]
    private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

    [DllImport("user32.dll")]
    private static extern int CallNextHookEx(
      IntPtr idHook,
      int nCode,
      int wParam,
      ref globalKeyboardHook.keyboardHookStruct lParam);

    [DllImport("kernel32.dll")]
    private static extern IntPtr LoadLibrary(string lpFileName);

    public delegate int keyboardHookProc(
      int code,
      int wParam,
      ref globalKeyboardHook.keyboardHookStruct lParam);

    public struct keyboardHookStruct
    {
      public int vkCode;
      public int scanCode;
      public int flags;
      public int time;
      public int dwExtraInfo;
    }
  }
}
