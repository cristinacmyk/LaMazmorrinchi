//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Controles/Controles.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controles : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""981f8d6b-af3e-408c-83ad-4403fb5ed048"",
            ""actions"": [
                {
                    ""name"": ""Interactuar"",
                    ""type"": ""Button"",
                    ""id"": ""d055222b-88a6-409e-a3b4-37fcf3603383"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Moverse"",
                    ""type"": ""Value"",
                    ""id"": ""cef95511-49a4-4e00-bfd3-3a25d501ff0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotarCamara"",
                    ""type"": ""Value"",
                    ""id"": ""95bdf392-17d2-4ac9-9686-a61c5a9dc3e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""7d254893-bbf5-459d-a6e5-79b8d173a8bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""896737fb-bf5d-417f-91d0-83ba213fd052"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Interactuar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""95e1051e-c8cf-463e-83da-dd6e5fa25af2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e23771b-aef7-41ad-84e7-60bee04ebd7c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e818162a-3439-4d58-8b48-ea6cc59964cb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7570e46b-4062-44c6-b10a-26926e949be6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""caa995ae-9410-4f42-b12a-786bdc478d7f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Flechas"",
                    ""id"": ""af933fbf-9c83-4fe8-8ba4-b7ba0af998b2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1cf208c2-ec9f-437a-8c30-7985d6724dda"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8a2f9ef1-c163-4c05-9b5c-a0f62d35161e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f84e562b-70b7-43ef-b52f-c89b8e5bc942"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""032a548e-9a80-4186-88da-5f13834f6f42"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0c0e8a96-0c7a-4f8a-be13-8da05b50fd1b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Moverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aae70bb5-a442-41d7-bd49-7874d79a60bf"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotarCamara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7569e65f-af2f-4273-85bb-417b910737a6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""RotarCamara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d50df9c5-0ad1-422b-989f-1c54ad0dea2e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b738718e-6aad-4157-af13-e24c5a4161dc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Teclado"",
            ""bindingGroup"": ""Teclado"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Interactuar = m_Gameplay.FindAction("Interactuar", throwIfNotFound: true);
        m_Gameplay_Moverse = m_Gameplay.FindAction("Moverse", throwIfNotFound: true);
        m_Gameplay_RotarCamara = m_Gameplay.FindAction("RotarCamara", throwIfNotFound: true);
        m_Gameplay_Saltar = m_Gameplay.FindAction("Saltar", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Interactuar;
    private readonly InputAction m_Gameplay_Moverse;
    private readonly InputAction m_Gameplay_RotarCamara;
    private readonly InputAction m_Gameplay_Saltar;
    public struct GameplayActions
    {
        private @Controles m_Wrapper;
        public GameplayActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interactuar => m_Wrapper.m_Gameplay_Interactuar;
        public InputAction @Moverse => m_Wrapper.m_Gameplay_Moverse;
        public InputAction @RotarCamara => m_Wrapper.m_Gameplay_RotarCamara;
        public InputAction @Saltar => m_Wrapper.m_Gameplay_Saltar;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Interactuar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractuar;
                @Interactuar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractuar;
                @Interactuar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractuar;
                @Moverse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoverse;
                @Moverse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoverse;
                @Moverse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoverse;
                @RotarCamara.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotarCamara;
                @RotarCamara.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotarCamara;
                @RotarCamara.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotarCamara;
                @Saltar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSaltar;
                @Saltar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSaltar;
                @Saltar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSaltar;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interactuar.started += instance.OnInteractuar;
                @Interactuar.performed += instance.OnInteractuar;
                @Interactuar.canceled += instance.OnInteractuar;
                @Moverse.started += instance.OnMoverse;
                @Moverse.performed += instance.OnMoverse;
                @Moverse.canceled += instance.OnMoverse;
                @RotarCamara.started += instance.OnRotarCamara;
                @RotarCamara.performed += instance.OnRotarCamara;
                @RotarCamara.canceled += instance.OnRotarCamara;
                @Saltar.started += instance.OnSaltar;
                @Saltar.performed += instance.OnSaltar;
                @Saltar.canceled += instance.OnSaltar;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_TecladoSchemeIndex = -1;
    public InputControlScheme TecladoScheme
    {
        get
        {
            if (m_TecladoSchemeIndex == -1) m_TecladoSchemeIndex = asset.FindControlSchemeIndex("Teclado");
            return asset.controlSchemes[m_TecladoSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnInteractuar(InputAction.CallbackContext context);
        void OnMoverse(InputAction.CallbackContext context);
        void OnRotarCamara(InputAction.CallbackContext context);
        void OnSaltar(InputAction.CallbackContext context);
    }
}
