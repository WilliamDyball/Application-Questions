using System.Collections.Generic;
using UnityEngine;

class Board {
    public:
        enum JewelKind : int {
        Empty,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    };

    enum MoveDirection : int {
        Up,
        Down,
        Left,
        Right
    };

    struct Move {
        int x;
        int y;
        MoveDirection direction;
    };

    int GetWidth();
    int GetHeight();

    JewelKind GetJewel(int x, int y);
    void SetJewel(int x, int y, JewelKind kind);

    //Implement this function
    Move CalculateBestMoveForBoard() {
        List<Move> movesToCheck = new List<Move>();
        int iTempY = 0, iTempX = 0, iMatches = 0, iBestMatches = 0;
        Move bestMove = new Move();
        bool bFoundA = true, bFoundB = true;
        for (int x = 0; x < GetHeight(); x++) {
            for (int y = 0; y < GetWidth(); y++) {
                int iWidth = GetWidth();
                int iHeight = GetHeight();
                if (x > 0) {
                    movesToCheck.Add(new Move(x, y, MoveDirection.Left));
                }
                if (x < GetWidth()) {
                    movesToCheck.Add(new Move(x, y, MoveDirection.Right));
                }
                if (y > 0) {
                    movesToCheck.Add(new Move(x, y, MoveDirection.Down));
                }
                if (y < GetHeight()) {
                    movesToCheck.Add(new Move(x, y, MoveDirection.Up));
                }
            }
        }
        for (int i = 0; i < movesToCheck.Count(); i++) {
            //Check if at bounds of grid
            //Check if x-/+1 and y-/+1 match x,y
            //If true check the next one that would be in the match
            iTempX = movesToCheck[i].x;
            iTempY = movesToCheck[i].y;
            switch (movesToCheck[i].direction) {
                case MoveDirection.Left:
                    while (bFoundA || bFoundB) {
                        if (iTempY > 0) {//Bounds check
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX - 1, iTempY - (iMatches + 1))) {//Up and left
                                    iMatches++;
                                } else {
                                    bFoundA = false;
                                }
                            }
                        }
                        if (iTempY < GetHeight()) {
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX - 1, iTempY + (iMatches + 1))) {//Down and left
                                    iMatches++;
                                } else {
                                    bFoundB = false;
                                }
                            }
                        }
                    }
                    break;
                case MoveDirection.Right:
                    while (bFoundA || bFoundB) {
                        if (iTempY > 0) {//Bounds check
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX + 1, iTempY - (iMatches + 1))) {//Up and right
                                    iMatches++;
                                } else {
                                    bFoundA = false;
                                }
                            }
                        }
                        if (iTempY < GetHeight()) {
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX + 1, iTempY + (iMatches + 1))) {//Down and right
                                    iMatches++;
                                } else {
                                    bFoundB = false;
                                }
                            }
                        }
                    }
                    break;
                case MoveDirection.Up:
                    while (bFoundA || bFoundB) {
                        if (iTempY > 0) {//Bounds check
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX - 1, iTempY - (iMatches + 1))) {//Up and left
                                    iMatches++;
                                } else {
                                    bFoundA = false;
                                }
                            }
                        }
                        if (iTempY < GetHeight()) {
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX + 1, iTempY + (iMatches + 1))) {//Up and right
                                    iMatches++;
                                } else {
                                    bFoundB = false;
                                }
                            }
                        }
                    }
                    break;
                case MoveDirection.Down:
                    while (bFoundA || bFoundB) {
                        if (iTempY > 0) {//Bounds check
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX - 1, iTempY - (iMatches + 1))) {//Down and left
                                    iMatches++;
                                } else {
                                    bFoundA = false;
                                }
                            }
                        }
                        if (iTempY < GetHeight()) {
                            if (bFoundA) {//Remains true if found a match before
                                if (GetJewel(iTempX, iTempY) == GetJewel(iTempX + 1, iTempY - (iMatches + 1))) {//Down and right
                                    iMatches++;
                                } else {
                                    bFoundB = false;
                                }
                            }
                        }
                    }
                    break;
                default:
                    //Show error message
                    break;
            }
            if (iMatches > iBestMatches) {
                iBestMatches = iMatches;
                bestMove = movesToCheck[i];
            }
        }
        return bestMove;
    }
};