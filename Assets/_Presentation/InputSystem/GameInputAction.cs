//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Presentation/InputSystem/GameInputAction.inputactions
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

public partial class @GameInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputAction"",
    ""maps"": [
        {
            ""name"": ""GlobalActionMap"",
            ""id"": ""f67515db-74dd-4d61-9383-d938d5c4aae7"",
            ""actions"": [
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""a2a2f3ef-1859-4854-bc4d-ee5e9bd4a01f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""435bf314-42dd-464b-91bf-71da91bde928"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""42148fe3-e447-4c86-adeb-e84fdcddf755"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""2d9da20d-b2ea-4db6-afae-a9d6cc6efc78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1908de4a-6d3c-4bc8-9892-d04e268c0f3d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de906ba9-04e4-4602-b065-eb01f486a1f0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0209251-2cec-4306-8d84-1b0ca6927799"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3b75409-c5d9-4045-9bfc-51d4cf7bb42d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""830a15a7-8cec-4ad1-ace8-b6106b9f20dc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a62a1293-12e2-4c46-afe9-6663724149e8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9762fa95-70c9-4bd5-a859-29a5a06bba7d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GlobalActionMap
        m_GlobalActionMap = asset.FindActionMap("GlobalActionMap", throwIfNotFound: true);
        m_GlobalActionMap_MoveRight = m_GlobalActionMap.FindAction("MoveRight", throwIfNotFound: true);
        m_GlobalActionMap_MoveLeft = m_GlobalActionMap.FindAction("MoveLeft", throwIfNotFound: true);
        m_GlobalActionMap_Jump = m_GlobalActionMap.FindAction("Jump", throwIfNotFound: true);
        m_GlobalActionMap_Slide = m_GlobalActionMap.FindAction("Slide", throwIfNotFound: true);
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

    // GlobalActionMap
    private readonly InputActionMap m_GlobalActionMap;
    private List<IGlobalActionMapActions> m_GlobalActionMapActionsCallbackInterfaces = new List<IGlobalActionMapActions>();
    private readonly InputAction m_GlobalActionMap_MoveRight;
    private readonly InputAction m_GlobalActionMap_MoveLeft;
    private readonly InputAction m_GlobalActionMap_Jump;
    private readonly InputAction m_GlobalActionMap_Slide;
    public struct GlobalActionMapActions
    {
        private @GameInputAction m_Wrapper;
        public GlobalActionMapActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_GlobalActionMap_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_GlobalActionMap_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_GlobalActionMap_Jump;
        public InputAction @Slide => m_Wrapper.m_GlobalActionMap_Slide;
        public InputActionMap Get() { return m_Wrapper.m_GlobalActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IGlobalActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_GlobalActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GlobalActionMapActionsCallbackInterfaces.Add(instance);
            @MoveRight.started += instance.OnMoveRight;
            @MoveRight.performed += instance.OnMoveRight;
            @MoveRight.canceled += instance.OnMoveRight;
            @MoveLeft.started += instance.OnMoveLeft;
            @MoveLeft.performed += instance.OnMoveLeft;
            @MoveLeft.canceled += instance.OnMoveLeft;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Slide.started += instance.OnSlide;
            @Slide.performed += instance.OnSlide;
            @Slide.canceled += instance.OnSlide;
        }

        private void UnregisterCallbacks(IGlobalActionMapActions instance)
        {
            @MoveRight.started -= instance.OnMoveRight;
            @MoveRight.performed -= instance.OnMoveRight;
            @MoveRight.canceled -= instance.OnMoveRight;
            @MoveLeft.started -= instance.OnMoveLeft;
            @MoveLeft.performed -= instance.OnMoveLeft;
            @MoveLeft.canceled -= instance.OnMoveLeft;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Slide.started -= instance.OnSlide;
            @Slide.performed -= instance.OnSlide;
            @Slide.canceled -= instance.OnSlide;
        }

        public void RemoveCallbacks(IGlobalActionMapActions instance)
        {
            if (m_Wrapper.m_GlobalActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGlobalActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_GlobalActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GlobalActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GlobalActionMapActions @GlobalActionMap => new GlobalActionMapActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IGlobalActionMapActions
    {
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
    }
}
