using System;
using SharpDX.XInput;


namespace GeometryFriends.Input
{
    internal enum ControllerKeys
    {
        BUTTON_UP,
        BUTTON_DOWN,
        BUTTON_LEFT,
        BUTTON_RIGHT,
        BACK,
        START,
        BUTTON_X,
        BUTTON_A,
        BUTTON_B,
        BUTTON_Y
    }

    internal enum ControllerIndex
    {
        CONTROLLER_1,
        CONTROLLER_2
    }
    class ControllerHandler
    {
        private Controller controllerCircle;
        private Controller controllerRectangle;

        private State oldStateCircle;
        private State newStateCircle;
        private State oldStateRectangle;
        private State newStateRectangle;

        //private Controller controller2;

        public ControllerHandler() {
            controllerCircle = new Controller(UserIndex.One);
            controllerRectangle = new Controller(UserIndex.Two);
            if (isControllerOn(ControllerIndex.CONTROLLER_1))
            {
                newStateCircle = controllerCircle.GetState();
            }
            if (isControllerOn(ControllerIndex.CONTROLLER_2))
            {
                newStateRectangle = controllerRectangle.GetState();
            }
        }


        public void UpdateState()
        {           
            if (isControllerOn(ControllerIndex.CONTROLLER_1))
            {
                oldStateCircle = newStateCircle;
                newStateCircle = controllerCircle.GetState();
            }
            if (isControllerOn(ControllerIndex.CONTROLLER_2))
            {
                oldStateRectangle = newStateRectangle;
                newStateRectangle = controllerRectangle.GetState();
            }
        }

        public bool isControllerOn(ControllerIndex num)
        {
            if (num == ControllerIndex.CONTROLLER_1)
            {
                if (controllerCircle.IsConnected)
                {
                    return true;
                }
            }
            if (num == ControllerIndex.CONTROLLER_2)
            {
                if (controllerRectangle.IsConnected)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsKeyPressed(ControllerIndex num, ControllerKeys key)
        {
            if (num == ControllerIndex.CONTROLLER_1)
            {
                return CheckKeyPressed(1, key);
            }
            if (num == ControllerIndex.CONTROLLER_2)
            {
                return CheckKeyPressed(2, key);
            }
            return false;
        }

        private bool CheckKeyPressed(int player, ControllerKeys key)
        {
            State newState;
            State oldState;
            if (player == 1)
            {
                newState = newStateCircle;
                oldState = oldStateCircle;
            }
            else
            {
                newState = newStateRectangle;
                oldState = oldStateRectangle;
            }

            bool result = false;
            switch (key)
            {               
               case ControllerKeys.BUTTON_UP:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp));
                    break;
                case ControllerKeys.BUTTON_DOWN:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown));
                    break;
                case ControllerKeys.BUTTON_LEFT:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft));
                    break;
                case ControllerKeys.BUTTON_RIGHT:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));
                    break;
                case ControllerKeys.START:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start));
                    break;
                case ControllerKeys.BACK:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back));
                    break;
                case ControllerKeys.BUTTON_X:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X));
                    break;
                case ControllerKeys.BUTTON_A:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A));
                    break;
                case ControllerKeys.BUTTON_B:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B));
                    break;
                case ControllerKeys.BUTTON_Y:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y) && !oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y));
                    break;
            }

            return result;
        }

        public bool IsKeyHeld(ControllerIndex num, ControllerKeys key)
        {
            if (num == ControllerIndex.CONTROLLER_1)
            {
                return CheckKeyHeld(1, key);
            }
            if (num == ControllerIndex.CONTROLLER_2)
            {
                return CheckKeyHeld(2, key);
            }
            return false;
        }

        private bool CheckKeyHeld(int player, ControllerKeys key)
        {
            State newState;
            State oldState;
            if (player == 1)
            {
                newState = newStateCircle;
                oldState = oldStateCircle;
            }
            else
            {
                newState = newStateRectangle;
                oldState = oldStateRectangle;
            }

            bool result = false;
            switch (key)
            {
                case ControllerKeys.BUTTON_UP:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp));
                    break;
                case ControllerKeys.BUTTON_DOWN:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown));
                    break;
                case ControllerKeys.BUTTON_LEFT:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft));
                    break;
                case ControllerKeys.BUTTON_RIGHT:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));
                    break;
                case ControllerKeys.START:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start));
                    break;
                case ControllerKeys.BACK:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back));
                    break;
                case ControllerKeys.BUTTON_X:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X));
                    break;
                case ControllerKeys.BUTTON_A:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A));
                    break;
                case ControllerKeys.BUTTON_B:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B));
                    break;
                case ControllerKeys.BUTTON_Y:
                    result = (newState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y) && oldState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y));
                    break;
            }

            return result;
        }       

    }

}
