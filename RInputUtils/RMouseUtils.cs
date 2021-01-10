using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace ReallyifsUtils.RInputUtils
{
    /// <summary>
    /// 如果你要使用此工具，请在你的 <see cref="Mod.PostUpdateInput"/> 中使用 <see cref="MouseStateUpdate"/>
    /// </summary>
    public static class RMouseUtils
    {
        public const double MaxDoubleClickTime = 0.25;

        private static MouseState _state;
        private static MouseState _oldState;

        private static bool[] _clickList;
        private static byte[] _clickTimeList;

        public static MouseState State
        {
            get
            {
                CheckUpdate();
                return _state;
            }
        }

        public static MouseState OldState
        {
            get
            {
                CheckUpdate();
                return _oldState;
            }
        }

        #region All
        /// <summary>
        /// <paramref name="mouse"/> 代表的键是否被单击
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool MouseClick(RMouseEnum mouse)
        {
            if (mouse.HasFlag(RMouseEnum.MouseLeft) && LeftClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseMiddle) && MiddleClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseRight) && RightClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX1) && XButton1Click())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX2) && XButton2Click())
                return true;
            return false;
        }


        /// <summary>
        /// <paramref name="mouse"/> 代表的键是否被双击
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool MouseDoubleClick(RMouseEnum mouse)
        {
            if (mouse.HasFlag(RMouseEnum.MouseLeft) && LeftDoubleClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseMiddle) && MiddleDoubleClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseRight) && RightDoubleClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX1) && XButton1DoubleClick())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX2) && XButton2DoubleClick())
                return true;
            return false;
        }

        /// <summary>
        /// <paramref name="mouse"/> 代表的键是否按下
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool MousePressed(RMouseEnum mouse)
        {
            if (mouse.HasFlag(RMouseEnum.MouseLeft) && LeftPressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseMiddle) && MiddlePressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseRight) && RightPressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX1) && XButton1Pressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX2) && XButton2Pressed())
                return true;
            return false;
        }

        /// <summary>
        /// <paramref name="mouse"/> 代表的键是否松开
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool MouseReleased(RMouseEnum mouse)
        {
            if (mouse.HasFlag(RMouseEnum.MouseLeft) && LeftReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseMiddle) && MiddleReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseRight) && RightReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX1) && XButton1Released())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX2) && XButton2Released())
                return true;
            return false;
        }

        /// <summary>
        /// <paramref name="mouse"/> 代表的键在上一帧是否按下
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool MousePrePressed(RMouseEnum mouse)
        {
            if (mouse.HasFlag(RMouseEnum.MouseLeft) && LeftPrePressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseMiddle) && MiddlePrePressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseRight) && RightPrePressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX1) && XButton1PrePressed())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX2) && XButton2PrePressed())
                return true;
            return false;
        }

        /// <summary>
        /// <paramref name="mouse"/> 代表的键在上一帧是否松开
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool MousePreReleased(RMouseEnum mouse)
        {
            if (mouse.HasFlag(RMouseEnum.MouseLeft) && LeftPreReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseMiddle) && MiddlePreReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseRight) && RightPreReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX1) && XButton1PreReleased())
                return true;
            if (mouse.HasFlag(RMouseEnum.MouseX2) && XButton2PreReleased())
                return true;
            return false;
        }
        #endregion

        #region Left
        /// <summary>
        /// 鼠标左键是否被单击
        /// </summary>
        /// <returns></returns>
        public static bool LeftClick()
        {
            if (OldState.LeftButton == ButtonState.Pressed && State.LeftButton == ButtonState.Released)
            {
                _clickList[(int)RMouseEnum.MouseLeft] = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标左键是否被双击
        /// </summary>
        /// <returns></returns>
        public static bool LeftDoubleClick()
        {
            if (_clickList[(int)RMouseEnum.MouseLeft]
                && OldState.LeftButton == ButtonState.Pressed
                && State.LeftButton == ButtonState.Released)
            {
                ListReset(RMouseEnum.MouseLeft);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标左键是否按下
        /// </summary>
        /// <returns></returns>
        public static bool LeftPressed() => State.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// 鼠标左键是否松开
        /// </summary>
        /// <returns></returns>
        public static bool LeftReleased() => State.LeftButton == ButtonState.Released;

        /// <summary>
        /// 鼠标左键在上一帧是否按下
        /// </summary>
        /// <returns></returns>
        public static bool LeftPrePressed() => OldState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// 鼠标左键在上一帧是否松开
        /// </summary>
        /// <returns></returns>
        public static bool LeftPreReleased() => OldState.LeftButton == ButtonState.Released;
        #endregion

        #region Middle
        /// <summary>
        /// 鼠标中键是否被单击
        /// </summary>
        /// <returns></returns>
        public static bool MiddleClick()
        {
            if (OldState.MiddleButton == ButtonState.Pressed && State.MiddleButton == ButtonState.Released)
            {
                _clickList[(int)RMouseEnum.MouseMiddle] = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标中键是否被双击
        /// </summary>
        /// <returns></returns>
        public static bool MiddleDoubleClick()
        {
            if (_clickList[(int)RMouseEnum.MouseMiddle]
                && OldState.MiddleButton == ButtonState.Pressed
                && State.MiddleButton == ButtonState.Released)
            {
                ListReset(RMouseEnum.MouseMiddle);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标中键是否按下
        /// </summary>
        /// <returns></returns>
        public static bool MiddlePressed() => State.MiddleButton == ButtonState.Pressed;

        /// <summary>
        /// 鼠标中键是否松开
        /// </summary>
        /// <returns></returns>
        public static bool MiddleReleased() => State.MiddleButton == ButtonState.Released;

        /// <summary>
        /// 鼠标中键在上一帧是否按下
        /// </summary>
        /// <returns></returns>
        public static bool MiddlePrePressed() => OldState.MiddleButton == ButtonState.Pressed;

        /// <summary>
        /// 鼠标中键在上一帧是否松开
        /// </summary>
        /// <returns></returns>
        public static bool MiddlePreReleased() => OldState.MiddleButton == ButtonState.Released;
        #endregion

        #region Right
        /// <summary>
        /// 鼠标右键是否被单击
        /// </summary>
        /// <returns></returns>
        public static bool RightClick()
        {
            if (OldState.RightButton == ButtonState.Pressed && State.RightButton == ButtonState.Released)
            {
                _clickList[(int)RMouseEnum.MouseRight] = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标右键是否被双击
        /// </summary>
        /// <returns></returns>
        public static bool RightDoubleClick()
        {
            if (_clickList[(int)RMouseEnum.MouseRight]
                && OldState.RightButton == ButtonState.Pressed
                && State.RightButton == ButtonState.Released)
            {
                ListReset(RMouseEnum.MouseRight);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标右键是否按下
        /// </summary>
        /// <returns></returns>
        public static bool RightPressed() => State.RightButton == ButtonState.Pressed;

        /// <summary>
        /// 鼠标右键是否松开
        /// </summary>
        /// <returns></returns>
        public static bool RightReleased() => State.RightButton == ButtonState.Released;

        /// <summary>
        /// 鼠标右键在上一帧是否按下
        /// </summary>
        /// <returns></returns>
        public static bool RightPrePressed() => OldState.RightButton == ButtonState.Pressed;

        /// <summary>
        /// 鼠标右键在上一帧是否松开
        /// </summary>
        /// <returns></returns>
        public static bool RightPreReleased() => OldState.RightButton == ButtonState.Released;
        #endregion

        #region X Button 1
        /// <summary>
        /// 鼠标X1是否被单击
        /// </summary>
        /// <returns></returns>
        public static bool XButton1Click()
        {
            if (OldState.XButton1 == ButtonState.Pressed && State.XButton1 == ButtonState.Released)
            {
                _clickList[(int)RMouseEnum.MouseX1] = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标X1是否被双击
        /// </summary>
        /// <returns></returns>
        public static bool XButton1DoubleClick()
        {
            if (_clickList[(int)RMouseEnum.MouseX1]
                && OldState.XButton1 == ButtonState.Pressed
                && State.XButton1 == ButtonState.Released)
            {
                ListReset(RMouseEnum.MouseX1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标X1是否按下
        /// </summary>
        /// <returns></returns>
        public static bool XButton1Pressed() => State.XButton1 == ButtonState.Pressed;

        /// <summary>
        /// 鼠标X1是否松开
        /// </summary>
        /// <returns></returns>
        public static bool XButton1Released() => State.XButton1 == ButtonState.Released;

        /// <summary>
        /// 鼠标X1在上一帧是否按下
        /// </summary>
        /// <returns></returns>
        public static bool XButton1PrePressed() => OldState.XButton1 == ButtonState.Pressed;

        /// <summary>
        /// 鼠标X1在上一帧是否松开
        /// </summary>
        /// <returns></returns>
        public static bool XButton1PreReleased() => OldState.XButton1 == ButtonState.Released;
        #endregion

        #region X Button 2
        /// <summary>
        /// 鼠标X2是否被单击
        /// </summary>
        /// <returns></returns>
        public static bool XButton2Click()
        {
            if (OldState.XButton2 == ButtonState.Pressed && State.XButton2 == ButtonState.Released)
            {
                _clickList[(int)RMouseEnum.MouseX2] = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标X2是否被双击
        /// </summary>
        /// <returns></returns>
        public static bool XButton2DoubleClick()
        {
            if (_clickList[(int)RMouseEnum.MouseX2]
                && OldState.XButton2 == ButtonState.Pressed
                && State.XButton2 == ButtonState.Released)
            {
                ListReset(RMouseEnum.MouseX2);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 鼠标X2是否按下
        /// </summary>
        /// <returns></returns>
        public static bool XButton2Pressed() => State.XButton2 == ButtonState.Pressed;

        /// <summary>
        /// 鼠标X2是否松开
        /// </summary>
        /// <returns></returns>
        public static bool XButton2Released() => State.XButton2 == ButtonState.Released;

        /// <summary>
        /// 鼠标X2在上一帧是否按下
        /// </summary>
        /// <returns></returns>
        public static bool XButton2PrePressed() => OldState.XButton2 == ButtonState.Pressed;

        /// <summary>
        /// 鼠标X2在上一帧是否松开
        /// </summary>
        /// <returns></returns>
        public static bool XButton2PreReleased() => OldState.XButton2 == ButtonState.Released;
        #endregion

        private static void CheckUpdate()
        {
            if (_state == null || _oldState == null)
            {
                _state = Mouse.GetState();
                _oldState = _state;
            }
            if (_clickList == null || _clickTimeList == null)
            {
                _clickList = new bool[5];
                _clickTimeList = new byte[5];
            }
        }

        private static void ListReset(RMouseEnum mouse)
        {
            _clickList[(int)mouse] = false;
            _clickTimeList[(int)mouse] = 0;
        }

        /// <summary>
        /// 更新 <see cref="RMouseUtils"/> 的状态
        /// </summary>
        public static void MouseStateUpdate()
        {
            CheckUpdate();
            for (int i = 0; i < _clickList.Length; i++)
            {
                if (_clickTimeList[i] > MaxDoubleClickTime)
                {
                    _clickList[i] = false;
                    _clickTimeList[i] = 0;
                }
                if (_clickList[i])
                    _clickTimeList[i]++;
            }
        }
    }
}