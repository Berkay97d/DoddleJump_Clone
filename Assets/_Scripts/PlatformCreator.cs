using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformArray;
    [SerializeField] private Transform _platformParent;
    
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
                Instantiate(_platformArray[0], Vector3.zero, Quaternion.identity, _platformParent);
                continue;
            }
            
            Instantiate(randomPlatform, new Vector3(0, index * 11, 0), Quaternion.identity, _platformParent);
        }
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, _platformArray.Length);
    }
}