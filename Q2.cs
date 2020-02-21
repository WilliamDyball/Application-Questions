bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w, ref float xPosition) {
    //Equation used y = position.y + velocity.y * t + 0.5 * Gravity * t^2
    //Where y is the displacement
    float fGravity = Gravity * 0.5f;
    float fVelocity = v.y;
    float fDisplacement = p.y - height;

    //Check if it will reach h
    if (((fVelocity * fVelocity) - 4f * fGravity * fDisplacement) < 0) {
        //xPosition = null;
        return false;
    }
    //Find t
    float t = (Math.Sqrt((fVelocity * fVelocity) - 4f * fGravity * fDisplacement) - fVelocity) / (2f * fGravity);
    float x = p.x + t * v.x;

    //Every other bounce results in the x being width - x 
    x = (x % (2f * width));
    if (x > width) {
        x = (2f * width) - x;
    }

    xPosition = x;
    return true;
}