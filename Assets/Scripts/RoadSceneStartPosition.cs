using UnityEngine;
using System.Collections;

namespace VRTK
{
   

    public class RoadSceneStartPosition : MonoBehaviour
    {

        public int position = 0;

        void Start()
        {
            GetComponent<Show_Details>().InteractableObjectUsed += new InteractableObjectEventHandler(SetStartingPosition);
    
    }

  
        void SetStartingPosition(object sender, InteractableObjectEventArgs e)
        {
            DataStore.setValue("road_position", position);
        }
    }
}