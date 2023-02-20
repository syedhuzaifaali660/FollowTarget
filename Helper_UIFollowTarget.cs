using UnityEngine;

public class Helper_UIFollowTarget : MonoBehaviour
{
    public Camera Camera2Follow;
    public float distance = 3.0F;
    public float height = 3.0F;
    public float smoothTime = 0.3F;
    public Vector3 worldRotation;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {

        //GETTING TARGET POSITION IN A TEMP VARIABLE
        Vector3 targetPosition = Camera2Follow.transform.TransformPoint(new Vector3(0, height, distance));

        //SMOOTHLY TRANSITION FROM OLD POS TO CURRENT POS
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        //CALCULATING THE POSITION TO LOOK AT
        var lookAtPos = new Vector3(Camera2Follow.transform.position.x, transform.position.y, Camera2Follow.transform.position.z);
        
        //MAKE OBJECT LOOK AT THE GIVE POSITION
        transform.LookAt(lookAtPos);

        //LOOK AT FUNCTION MAKES THE OBJECT LOOK AT Z DIRECTION FOR CANVAS IT MAKES IT REVERSE 
        //THIS IS USED TO CORRECT THE WORLD LOOK AT
        transform.Rotate(worldRotation);



    }
}
