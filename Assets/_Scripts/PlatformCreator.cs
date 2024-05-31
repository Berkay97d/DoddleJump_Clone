using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformArray;
    
    private void Start()
    {
        CreatePlatform();
    }
    
    
    private void CreatePlatform()
    {
        for (int index = 0; index < 500; index++)
        {
            int randomIndex = GetRandomIndex();
            GameObject randomPlatform = _platformArray[randomIndex];

            if (index == 0)
            {
                Instantiate(_platformArray[0], Vector3.zero, Quaternion.identity);
                continue;
            }
            
            Instantiate(randomPlatform, new Vector3(0, index * 10, 0), Quaternion.identity);
        }
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, _platformArray.Length);
    }
}