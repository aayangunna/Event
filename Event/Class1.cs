using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventAssignment
{
    /// <summary>
    /// This is the publisher class
    /// </summary>
    internal class AccessControl
    {
        public delegate void DoorSensorHandler();
        public event DoorSensorHandler Sensor;

        /// <summary>
        /// Detects if there is any movement
        /// </summary>
        public void MoveDetected()
        {
            Console.WriteLine("Detecting Movement");
            Thread.Sleep(5000);
            OnMoveDetected();
        }

        /// <summary>
        /// This method raises event on detecting movement
        /// </summary>
        public virtual void OnMoveDetected()
        {
            Sensor?.Invoke();
        }
    }

    /// <summary>
    /// Subscriber class that subscribes to 
    /// the AccessControl class
    /// </summary>
    public class CentralControl
    {

        public void GrantDet()
        {
            var access = new AccessControl();
            access.Sensor += OpenDoor;
            access.MoveDetected();
        }
        public void OpenDoor()
        {
            Console.WriteLine("A staff is approaching open the door");
        }
    }
}