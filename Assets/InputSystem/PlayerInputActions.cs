//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystem/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""308faea7-db8c-4981-8b7c-f39b4beaf21a"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6a51c1b1-5f8a-4773-b2a0-f2cf4d9d520b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9a23cf3a-9da5-4b3c-89c0-8dd1d386ddd2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""29d9f161-c438-4cb2-957d-4229edcfd0ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""8cdf9721-18e1-43d3-b8ab-c70bdecb0fa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""624b0eb1-3dbe-43c5-83f0-fcde7fe16edb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bc3aeb41-999f-4d50-ac43-fa6ef53236da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""66183411-a6c4-4159-a355-0fa03a7e32dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ff0f9311-dd19-4378-a06d-7f8e51956829"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a038af4f-55e1-41e7-8e98-8793391ed225"",
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
                    ""id"": ""db16ca21-5d84-445e-831b-aba663f01d78"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""38ff9a0c-22da-4a0a-8e06-aaba60e9aa88"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""96af50ae-996d-4dea-8491-343e45aca92b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""45979a00-f983-4fce-beb5-9248c0a9d2f3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a1a778a9-7ddf-42cd-a506-ceaf2334694f"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""422ef976-5564-4173-ab9f-234e69c7b07e"",
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
                    ""id"": ""0f51d7ef-f8ed-4a50-96ad-9b6f44c2b1b3"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1feba7db-cf79-48ee-b7a6-de34196fab29"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap,Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62c19514-f3b5-410a-bca7-f2d7167cf802"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56dd53cf-74d1-4654-8e38-58831346e85c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""642eeefc-a510-4961-9a35-f86a6b67904a"",
            ""actions"": [
                {
                    ""name"": ""Npc Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""c893644e-6f6c-40c3-9973-93ce9ee86fd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ManaStopInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""e15b5b6a-7573-4728-a4ad-b88eb3124f77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShallowGraveInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""b6f895cf-775d-44a1-9c10-99498ec38501"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3bb4bb1f-da80-4c83-8b17-187acf1d0a06"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Npc Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb1977a6-0de1-418d-885b-f76699b27e7e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ManaStopInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e5c8541-963d-48c3-bb7c-9338c8438848"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShallowGraveInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Drag = m_Player.FindAction("Drag", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Down = m_Player.FindAction("Down", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_NpcInteraction = m_Interaction.FindAction("Npc Interaction", throwIfNotFound: true);
        m_Interaction_ManaStopInteraction = m_Interaction.FindAction("ManaStopInteraction", throwIfNotFound: true);
        m_Interaction_ShallowGraveInteraction = m_Interaction.FindAction("ShallowGraveInteraction", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Drag;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Down;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Drag => m_Wrapper.m_Player_Drag;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Down => m_Wrapper.m_Player_Down;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Drag.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Down.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_NpcInteraction;
    private readonly InputAction m_Interaction_ManaStopInteraction;
    private readonly InputAction m_Interaction_ShallowGraveInteraction;
    public struct InteractionActions
    {
        private @PlayerInputActions m_Wrapper;
        public InteractionActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @NpcInteraction => m_Wrapper.m_Interaction_NpcInteraction;
        public InputAction @ManaStopInteraction => m_Wrapper.m_Interaction_ManaStopInteraction;
        public InputAction @ShallowGraveInteraction => m_Wrapper.m_Interaction_ShallowGraveInteraction;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @NpcInteraction.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnNpcInteraction;
                @NpcInteraction.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnNpcInteraction;
                @NpcInteraction.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnNpcInteraction;
                @ManaStopInteraction.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnManaStopInteraction;
                @ManaStopInteraction.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnManaStopInteraction;
                @ManaStopInteraction.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnManaStopInteraction;
                @ShallowGraveInteraction.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnShallowGraveInteraction;
                @ShallowGraveInteraction.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnShallowGraveInteraction;
                @ShallowGraveInteraction.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnShallowGraveInteraction;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NpcInteraction.started += instance.OnNpcInteraction;
                @NpcInteraction.performed += instance.OnNpcInteraction;
                @NpcInteraction.canceled += instance.OnNpcInteraction;
                @ManaStopInteraction.started += instance.OnManaStopInteraction;
                @ManaStopInteraction.performed += instance.OnManaStopInteraction;
                @ManaStopInteraction.canceled += instance.OnManaStopInteraction;
                @ShallowGraveInteraction.started += instance.OnShallowGraveInteraction;
                @ShallowGraveInteraction.performed += instance.OnShallowGraveInteraction;
                @ShallowGraveInteraction.canceled += instance.OnShallowGraveInteraction;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnNpcInteraction(InputAction.CallbackContext context);
        void OnManaStopInteraction(InputAction.CallbackContext context);
        void OnShallowGraveInteraction(InputAction.CallbackContext context);
    }
}
