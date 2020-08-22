using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator animator;
    private string levelNameToLoad;

	public void FadeToLevel (string levelName)
	{
        levelNameToLoad = levelName;
		animator.SetTrigger("FadeOut");
	}

    public void OnFadeComplete ()
	{
        SceneManager.LoadSceneAsync(levelNameToLoad);
	}
}
