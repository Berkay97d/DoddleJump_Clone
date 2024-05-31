using UnityEngine;

public class ObjectSpawner2D : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfObjects = 1000;
    public float yMin = 15f;
    public float yMax = 5000f;
    public float xMin = -2f;
    public float xMax = 2f;
    public float min;
    public float max;

    void Start()
    {
        float yPosition = yMin;
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (yPosition > yMax)
                break;

            Vector2 position = new Vector2(
                Random.Range(xMin, xMax),
                yPosition
            );

            Instantiate(objectToSpawn, position, Quaternion.identity);

            yPosition += Random.Range(min, max);
        }
    }
}