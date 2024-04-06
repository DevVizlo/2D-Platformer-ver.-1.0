using UnityEngine;

public class VampirizmAnimation : MonoBehaviour
{
    private const string VampirizmAnim = "Vampirizm";

    private Animator _raduisVampirism;

    private void Start()
    {
        _raduisVampirism = GetComponent<Animator>();
    }

    public void StartAnimationRadius()
    {
        _raduisVampirism.SetTrigger(VampirizmAnim);
    }
}
