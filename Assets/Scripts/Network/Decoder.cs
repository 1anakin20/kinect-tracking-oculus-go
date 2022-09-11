using System;
using System.IO;
using Tracking;
using UnityEngine;

namespace Network
{
    public class Decoder
    {
        public static Player GetPlayer(string skeletonData)
        {
            /*
             * Format:
             * skeleton_number,joint,x,y,z\n
             */
            Vector3 head = new Vector3();
            Vector3 leftHand = new Vector3();
            Vector3 rightHand = new Vector3();
            using (var reader = new StringReader(skeletonData))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    var parts = line.Split(',');
                    var x = float.Parse(parts[2]);
                    var y = float.Parse(parts[3]);
                    var z = float.Parse(parts[4]);
                    var jointPosition = new Vector3(x, y, z);
                    switch (parts[1])
                    {
                        case "Head":
                            head = jointPosition;
                            break;
                        case "HandLeft":
                            leftHand = jointPosition;
                            break;
                        case "HandRight":
                            rightHand = jointPosition;
                            break;
                    }
                }
            }
            return new Player(head, leftHand, rightHand);
        }
    }
}