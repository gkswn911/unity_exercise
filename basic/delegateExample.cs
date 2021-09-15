using UnityEngine; 

public class DelegateExample : MonoBehaviour 
{ 
    delegate T CalculateDelegate<T>(T a, T b); 

    void Start() 
    { 
        CalculateDelegate<int> Plus = new CalculateDelegate<int>(Add); 
        CalculateDelegate<float> Minus = new CalculateDelegate<float>(Subtract); 

        DebugLog(1, 2, Plus); // 출력 : 3  
        DebugLog(4.1f, 3.2f, Minus); // 출력 : 0.9  
    } 

    void DebugLog<T>(T a, T b, CalculateDelegate<T> calculateDelegate) 
    { 
        Debug.Log(calculateDelegate(a, b)); 
    } 

    int Add(int a, int b) 
    { 
        return a + b; 
    } 

    float Subtract(float a, float b) 
    { 
        return a - b; 
    } 
}
