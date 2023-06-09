//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Actions.inputactions
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

public partial class @Actions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""Fight"",
            ""id"": ""bb41b97b-31e3-478b-8099-5032349e7783"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""510d3a86-a27c-46e9-a9cc-3e6982821598"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""53e02bc9-fe6f-46e2-a0eb-2f11884e20ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Value"",
                    ""id"": ""7a1aff2f-cf51-4767-ab9c-9516067b4108"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SwitchStance"",
                    ""type"": ""Button"",
                    ""id"": ""14c84945-bf85-4688-b97e-f3fc28b61965"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateSelf"",
                    ""type"": ""Button"",
                    ""id"": ""40429ee9-6e72-419a-97e9-9e2810e93310"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d2ebca9-0e66-45b6-aa93-b8781abd797f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KyeBoard"",
                    ""id"": ""e5d4ae6a-7b71-4a05-af0c-228ee5221f2b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0bcf1b4-c2de-4664-8741-24ee42b17ea8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""54deaaad-4b2b-4b67-85b1-42d6668e6858"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc3a94e9-ded0-4f17-a8d2-71e671c89053"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ca25b3f-cbf8-46cb-a204-147669474768"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9bb97add-9953-4895-8a87-5b3dded92500"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""5206a05e-1367-47ab-9028-b0714abab357"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ee060a98-72e0-4467-b072-5f53325df853"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""31e4ecf5-9d56-41da-ac3e-a78aa063ff51"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ea275784-9139-47bd-a69e-81c6c2cef4dc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c3e2f5c9-059d-4e5d-8d46-757f55ea18e5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71b06934-82c8-42e3-bf90-271cb8746514"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchStance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0345bf56-1c7e-4b66-89d2-810ac39ffd72"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchStance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fff84b57-8bd4-4408-8beb-a429931d3c41"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""1ae676ae-3ea7-462b-8bad-e9ba23c6991e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""002cf3ce-818c-4b80-801a-c8180722d09d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a2a6465-8bb8-4317-8f48-3d4f0ea77b8a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d47f053c-32c6-43a0-9c1e-4723137a92f7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5f6b45a7-b5ff-45a9-b0f2-87f30b58d94c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a4c55360-8532-4bf3-ab3a-41f28fb1cff7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e73579f-0fed-46d7-8328-4b0adbf05a47"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Fight
        m_Fight = asset.FindActionMap("Fight", throwIfNotFound: true);
        m_Fight_Move = m_Fight.FindAction("Move", throwIfNotFound: true);
        m_Fight_Attack = m_Fight.FindAction("Attack", throwIfNotFound: true);
        m_Fight_Block = m_Fight.FindAction("Block", throwIfNotFound: true);
        m_Fight_SwitchStance = m_Fight.FindAction("SwitchStance", throwIfNotFound: true);
        m_Fight_RotateSelf = m_Fight.FindAction("RotateSelf", throwIfNotFound: true);
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

    // Fight
    private readonly InputActionMap m_Fight;
    private List<IFightActions> m_FightActionsCallbackInterfaces = new List<IFightActions>();
    private readonly InputAction m_Fight_Move;
    private readonly InputAction m_Fight_Attack;
    private readonly InputAction m_Fight_Block;
    private readonly InputAction m_Fight_SwitchStance;
    private readonly InputAction m_Fight_RotateSelf;
    public struct FightActions
    {
        private @Actions m_Wrapper;
        public FightActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Fight_Move;
        public InputAction @Attack => m_Wrapper.m_Fight_Attack;
        public InputAction @Block => m_Wrapper.m_Fight_Block;
        public InputAction @SwitchStance => m_Wrapper.m_Fight_SwitchStance;
        public InputAction @RotateSelf => m_Wrapper.m_Fight_RotateSelf;
        public InputActionMap Get() { return m_Wrapper.m_Fight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FightActions set) { return set.Get(); }
        public void AddCallbacks(IFightActions instance)
        {
            if (instance == null || m_Wrapper.m_FightActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FightActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Block.started += instance.OnBlock;
            @Block.performed += instance.OnBlock;
            @Block.canceled += instance.OnBlock;
            @SwitchStance.started += instance.OnSwitchStance;
            @SwitchStance.performed += instance.OnSwitchStance;
            @SwitchStance.canceled += instance.OnSwitchStance;
            @RotateSelf.started += instance.OnRotateSelf;
            @RotateSelf.performed += instance.OnRotateSelf;
            @RotateSelf.canceled += instance.OnRotateSelf;
        }

        private void UnregisterCallbacks(IFightActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Block.started -= instance.OnBlock;
            @Block.performed -= instance.OnBlock;
            @Block.canceled -= instance.OnBlock;
            @SwitchStance.started -= instance.OnSwitchStance;
            @SwitchStance.performed -= instance.OnSwitchStance;
            @SwitchStance.canceled -= instance.OnSwitchStance;
            @RotateSelf.started -= instance.OnRotateSelf;
            @RotateSelf.performed -= instance.OnRotateSelf;
            @RotateSelf.canceled -= instance.OnRotateSelf;
        }

        public void RemoveCallbacks(IFightActions instance)
        {
            if (m_Wrapper.m_FightActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFightActions instance)
        {
            foreach (var item in m_Wrapper.m_FightActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FightActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FightActions @Fight => new FightActions(this);
    public interface IFightActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnSwitchStance(InputAction.CallbackContext context);
        void OnRotateSelf(InputAction.CallbackContext context);
    }
}
