using UnityEngine;
using Console;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CustomCommands
{
    

    [ConsoleCommand("sm_selectObj", "Select an object in the SpawnManager")]
    class selObj : Command
    {
        public SpawnManager spawnmanager;
        public Joint2D hjoint;

        [CommandParameter("Object")]
        public string obj;
        public override ConsoleOutput Logic()
        {
            if (obj == "cube")
            {
                SpawnManager.Instance.cubeSelect();
                return new ConsoleOutput("Cube Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "circle")
            {
                SpawnManager.Instance.circleSelect();
                return new ConsoleOutput("Circle Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "ragdoll")
            {
                SpawnManager.Instance.ragSelect();
                return new ConsoleOutput("Ragdoll Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "rotor")
            {
                SpawnManager.Instance.rotorSelect();
                return new ConsoleOutput("Rotor Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "0Grag")
            {
                SpawnManager.Instance.posragSelect();
                return new ConsoleOutput("0-Gravity Ragdoll Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "light")
            {
                SpawnManager.Instance.lightSelect();
                return new ConsoleOutput("Light Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "radio")
            {
                SpawnManager.Instance.radioSelect();
                return new ConsoleOutput("Radio Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "bomb")
            {
                SpawnManager.Instance.bombSelect();
                return new ConsoleOutput("bomb Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "aciddroid")
            {
                SpawnManager.Instance.aciddroidSelect();
                return new ConsoleOutput("aciddroid Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "KCube")
            {
                SpawnManager.Instance.KCubeSelect();
                return new ConsoleOutput("Kinematic Cube Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "Gun")
            {
                SpawnManager.Instance.GunSelect();
                return new ConsoleOutput("Gun Selected", ConsoleOutput.OutputType.Log);
            }
            else if (obj == "Gravelbox")
            {
                SpawnManager.Instance.GbSelect();
                return new ConsoleOutput("[game] Selected", ConsoleOutput.OutputType.Log);
            }
            else
            {
                return new ConsoleOutput($"Unable to select object {obj}", ConsoleOutput.OutputType.Error);
            }
        }
    }

    [ConsoleCommand("sm_clearAll", "Clears Everything")]
    class clearAll : Command
    {
        public override ConsoleOutput Logic()
        {
            SpawnManager.Instance.DestroyAllOther();
            return new ConsoleOutput("Cleared Everything", ConsoleOutput.OutputType.Log);
        }
    }

    [ConsoleCommand("gm_activeDismembermentSensitivity", "Sets the dismemberment sensitivity of all active objects (Default 1000)")]
    class DisSens : Command
    {
        [CommandParameter("float")]
        public float sensitivity;

        public override ConsoleOutput Logic()
        {
            var objects = Object.FindObjectsOfType<GameObject>();
            foreach(GameObject foundjoint in objects)
            {
                if (foundjoint.GetComponent<HingeJoint2D>() != null)
                {
                    foundjoint.GetComponent<HingeJoint2D>().breakForce = sensitivity;
                    foundjoint.GetComponent<HingeJoint2D>().breakTorque = sensitivity;
                }
            }
            return new ConsoleOutput($"Set dismemberment sensitivity to {sensitivity}", ConsoleOutput.OutputType.Log);
        }
    }

    [ConsoleCommand("gm_activeRotorSpeed", "Sets the rotor speed of all active rotors (Default 1000, use negative numbers to go the other direction)")]
    class roSpeed : Command
    {
        [CommandParameter("float")]
        public float speed;

        public override ConsoleOutput Logic()
        {
            var rotors = 0;
            var objects = Object.FindObjectsOfType<GameObject>();
            foreach (GameObject foundjoint in objects)
            {
                if (foundjoint.GetComponent<toggleable>() != null)
                {
                    rotors += 1;
                    foundjoint.GetComponent<toggleable>().maxSpeed = speed;
                }
            }
            return new ConsoleOutput($"Found {rotors} rotors, Set rotor speed to {speed}", ConsoleOutput.OutputType.Log);
        }
    }

    [ConsoleCommand("gm_activateAllRotors", "Activates/deactivates all rotors in the scene")]
    class activR : Command
    {
        [CommandParameter("bool")]
        public bool on;

        public override ConsoleOutput Logic()
        {
            var rotors = Object.FindObjectsOfType<GameObject>();
            foreach (GameObject foundrotor in rotors)
            {
                if (foundrotor.GetComponent<toggleable>() != null)
                {
                    foundrotor.GetComponent<toggleable>().isOn = on;
                    foundrotor.GetComponent<toggleable>().rotorUpdate();
                }
            }
            return new ConsoleOutput($"Set rotor activation to {on}", ConsoleOutput.OutputType.Log);
        }
    }
    [ConsoleCommand("gm_detonateAll", "Detonates all explosives at once")]
    class detAll : Command
    {
        [CommandParameter("force")]
        public float force;
        [CommandParameter("radius")]
        public float radius;

        public override ConsoleOutput Logic()
        {
            var explosives = Object.FindObjectsOfType<GameObject>();
            foreach (GameObject foundexplosive in explosives)
            {
                if (foundexplosive.GetComponent<Kaboom>() != null)
                {
                    foundexplosive.GetComponent<Kaboom>().Explode(force, radius);
                }
            }
            return new ConsoleOutput($"Detonated All Explosives", ConsoleOutput.OutputType.Log);
        }
    }
}
