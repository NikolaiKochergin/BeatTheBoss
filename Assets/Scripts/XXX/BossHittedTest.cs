using UnityEngine;
using UnityEngine.UI;

public class BossHittedTest : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        _boss.BossHittedView.SetHitted(_slider.value);
    }
}