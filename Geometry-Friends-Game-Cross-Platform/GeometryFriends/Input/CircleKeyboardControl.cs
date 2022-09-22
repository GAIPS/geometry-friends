using GeometryFriends.XNAStub;

namespace GeometryFriends.Input
{
    internal class CircleKeyboardControl : CircleWiiInputSchema
    {
        public override bool Grow(InputState input)
        {                                   
            if (input.CurrentKeyboardState.IsKeyDown(Keys.S))
            {
                return true;
            }
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_1))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_1, ControllerKeys.BUTTON_Y))
                {
                    return true;
                }
            }
            return false;
        }

        public override float Jump(InputState input)
        {
            if (input.CurrentKeyboardState.IsKeyDown(Keys.W))
            {
                return 2;
            }
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_1))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_1, ControllerKeys.BUTTON_A))
                {
                    return 2;
                }
            }
            return 0;
        }

        public override bool MoveLeft(InputState input)
        {
            if (input.CurrentKeyboardState.IsKeyDown(Keys.A))
                return true;
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_1))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_1, ControllerKeys.BUTTON_LEFT))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool MoveRight(InputState input)
        {
            if (input.CurrentKeyboardState.IsKeyDown(Keys.D))
                return true;
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_1))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_1, ControllerKeys.BUTTON_RIGHT))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
