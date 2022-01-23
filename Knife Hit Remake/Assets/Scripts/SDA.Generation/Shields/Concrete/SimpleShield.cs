using UnityEngine;
using UnityEngine.Events;

namespace SDA.Generation
{
    public class SimpleShield : BaseShield
    {
        private float currentNormalizedTime; // procent czasu
        private float duration;
        private float startTime;
        private Vector3 startAngle;
        private Vector3 endAngle;

        private int currentStep;

        public override void Initialize(UnityAction onShieldHitCallback, UnityAction onWinCallback)
        {
            base.Initialize(onShieldHitCallback, onWinCallback);

            currentStep = 0;
            ShieldMovementStep currentStepData = movementScheme[currentStep];

            startTime = Time.time;
            duration = currentStepData.time;
            currentNormalizedTime = 0f;
            startAngle = transform.rotation.eulerAngles; // przeliczanie quaternionu na liczby eulerowskie
            endAngle = startAngle + Vector3.forward * currentStepData.angle; // Vector3.forward to to samo co Vector3(0,0,1)
        }

        public override void Rotate()
        {
            currentNormalizedTime = (Time.time - startTime) / duration;

            if (currentNormalizedTime >= 1f)
            {
                currentStep++;
                if (currentStep == movementScheme.Length)
                    currentStep = 0;

                ShieldMovementStep currentStepData = movementScheme[currentStep];

                startTime = Time.time;
                duration = currentStepData.time;
                currentNormalizedTime = 0f;
                startAngle = transform.rotation.eulerAngles; // przeliczanie quaternionu na liczby eulerowskie
                endAngle = startAngle + Vector3.forward * currentStepData.angle; // Vector3.forward to to samo co Vector3(0,0,1)
            }

            Vector3 finalAngle = Vector3.Lerp(startAngle, endAngle, currentNormalizedTime); // Liniowa interpolacja miêdzy dwoma punktami startAngle i endAngle w jakimœ momencie currentNormalizedTime
            transform.rotation = Quaternion.Euler(finalAngle);
        }
    } 
}
