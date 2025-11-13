using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public InputController()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventBus.Instance.Invoke(new WKeyPressedSignal());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventBus.Instance.Invoke(new AKeyPressedSignal());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            EventBus.Instance.Invoke(new DKeyPressedSignal());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.Instance.Invoke(new SKeyPressedSignal());
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            EventBus.Instance.Invoke(new WKeyReleasedSignal());
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            EventBus.Instance.Invoke(new AKeyReleasedSignal());
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            EventBus.Instance.Invoke(new DKeyReleasedSignal());
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            EventBus.Instance.Invoke(new SKeyReleasedSignal());
        } if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetSceneByName("Pause").isLoaded) {
                Time.timeScale = 1;
		        SceneSequence.UnloadPauseScene();
            } else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Time.timeScale = 0;
		        SceneSequence.LoadPauseSceneAdditive();
            }
        }
    }
}