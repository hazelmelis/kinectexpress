using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 6;
  


    // Update is called once per frame
    void Update()
    {

        Terrain terrain = Terrain.activeTerrain;

        Vector3 terrainPos = Terrain.activeTerrain.transform.position;
        Vector3 terrainSize = Terrain.activeTerrain.terrainData.size;

        float rightLimit = terrainPos.x + terrainSize.x / 2 - 1.5f;
        float leftLimit = terrainPos.x - terrainSize.x / 2 + 1f;

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
            }
            
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1, Space.World);
            }
        }
    }
}
