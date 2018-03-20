using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Academy.HoloToolkit.Unity
{
    public class GestureManager : Singleton<GestureManager>
    {
       
        // Currently active gesture recognizer.
        public GestureRecognizer ActiveRecognizer { get; private set; }

        public GestureRecognizer TapRecognizer { get; private set; }

        public bool IsTapping { get; private set; }

        public Vector3 TapPosition { get; private set; }

        public bool IsManipulating { get; private set; }
        
        void Awake()
        {
            TapRecognizer = new GestureRecognizer();
            TapRecognizer.SetRecognizableGestures(GestureSettings.Tap);
            TapRecognizer.Tapped += TapRecognizer_Tapped;
            ResetGestureRecognizers();
        }

        void OnDestroy()
        {
          TapRecognizer.Tapped -= TapRecognizer_Tapped;
        }

        /// <summary>
        /// Revert back to the default GestureRecognizer.
        /// </summary>
        public void ResetGestureRecognizers()
        {
            // Default to the navigation gestures.
            Transition(TapRecognizer);
        }

        /// <summary>
        /// Transition to a new GestureRecognizer.
        /// </summary>
        /// <param name="newRecognizer">The GestureRecognizer to transition to.</param>
        public void Transition(GestureRecognizer newRecognizer)
        {
            if (newRecognizer == null)
            {
                return;
            }

            if (ActiveRecognizer != null)
            {
                if (ActiveRecognizer == newRecognizer)
                {
                    return;
                }

                ActiveRecognizer.CancelGestures();
                ActiveRecognizer.StopCapturingGestures();
            }

            newRecognizer.StartCapturingGestures();
            ActiveRecognizer = newRecognizer;
        }

         private void TapRecognizer_Tapped(TappedEventArgs obj)
        {
            SendMessage("OnAirTapped");
        }
    }
}