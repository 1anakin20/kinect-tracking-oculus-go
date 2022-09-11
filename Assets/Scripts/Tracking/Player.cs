using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracking
{
    public class Player
    {
        public Vector3 Head { get; }
        public Vector3 LeftHand { get; }
        public Vector3 RightHand { get; }

        public Player(Vector3 head, Vector3 leftHand, Vector3 rightHand)
        {
            Head = head;
            LeftHand = leftHand;
            RightHand = rightHand;
        }

        public override string ToString()
        {
            return $"{nameof(Head)}: {Head}, {nameof(LeftHand)}: {LeftHand}, {nameof(RightHand)}: {RightHand}";
        }
    }
}
