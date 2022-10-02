//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Controles.inputactions
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
            ""name"": ""Topolino"",
            ""id"": ""89634a47-1311-43f1-b43f-045e665a3ed0"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""af4f4738-68bd-41f8-8a01-30d031574440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3a5e1a7e-039b-4ce6-aac4-8d08277f9442"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Value"",
                    ""id"": ""12575f55-3c56-43ef-9436-9d33cecd06a9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8be4e362-c771-40f6-b642-4aff1bda48c0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0b06b1a-6708-44bd-bb3f-20ee61d88e76"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""403d1b47-7caa-4d1f-ab57-0a65fddb7c6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c8915c0a-1a39-42a9-8278-19c4a096a325"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1ee31188-671a-48af-a647-2acb069d23c1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6bca6705-5190-4e40-9f2c-8a00b36a28a4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""41aed22d-9ce8-4d99-be87-5803f97fa678"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dd413c40-f537-46f0-8b27-3c132620a5da"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d5e2b43-d600-468e-8c9e-50291edab190"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85c980a5-e866-4b84-9145-c2c16fae25ac"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Topolino
        m_Topolino = asset.FindActionMap("Topolino", throwIfNotFound: true);
        m_Topolino_Jump = m_Topolino.FindAction("Jump", throwIfNotFound: true);
        m_Topolino_Movement = m_Topolino.FindAction("Movement", throwIfNotFound: true);
        m_Topolino_Grab = m_Topolino.FindAction("Grab", throwIfNotFound: true);
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

    // Topolino
    private readonly InputActionMap m_Topolino;
    private ITopolinoActions m_TopolinoActionsCallbackInterface;
    private readonly InputAction m_Topolino_Jump;
    private readonly InputAction m_Topolino_Movement;
    private readonly InputAction m_Topolino_Grab;
    public struct TopolinoActions
    {
        private @Controles m_Wrapper;
        public TopolinoActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Topolino_Jump;
        public InputAction @Movement => m_Wrapper.m_Topolino_Movement;
        public InputAction @Grab => m_Wrapper.m_Topolino_Grab;
        public InputActionMap Get() { return m_Wrapper.m_Topolino; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopolinoActions set) { return set.Get(); }
        public void SetCallbacks(ITopolinoActions instance)
        {
            if (m_Wrapper.m_TopolinoActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnMovement;
                @Grab.started -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_TopolinoActionsCallbackInterface.OnGrab;
            }
            m_Wrapper.m_TopolinoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
            }
        }
    }
    public TopolinoActions @Topolino => new TopolinoActions(this);
    public interface ITopolinoActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
    }
}
