using GeometryFriends.XNAStub;


namespace GeometryFriends.Input
{
    internal class RectangleKeyboardControl : RectangleWiiInputSchema
    {
        public override bool MorphDown(InputState input)
        {            
            if (input.CurrentKeyboardState.IsKeyDown(Keys.K))
                return true;
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_2))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_2, ControllerKeys.BUTTON_A))
                {
                    return true;
                }
            }
            return false;                    
        }

        public override bool MorphUp(InputState input)
        {
            if (input.CurrentKeyboardState.IsKeyDown(Keys.I))
                return true;
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_2))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_2, ControllerKeys.BUTTON_Y))
                {
                    return true;
                }
            }
            return false;
        }
        
        public override bool MoveLeft(InputState input)
        {
            if (input.CurrentKeyboardState.IsKeyDown(Keys.J))
                return true;
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_2))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_2, ControllerKeys.BUTTON_LEFT))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool MoveRight(InputState input)
        {
            if (input.CurrentKeyboardState.IsKeyDown(Keys.L))
                return true;
            if (input.controllerInput.isControllerOn(ControllerIndex.CONTROLLER_2))
            {
                if (input.controllerInput.IsKeyHeld(ControllerIndex.CONTROLLER_2, ControllerKeys.BUTTON_RIGHT))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
