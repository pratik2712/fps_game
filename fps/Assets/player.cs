// GENERATED AUTOMATICALLY FROM 'Assets/player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""player"",
    ""maps"": [
        {
            ""name"": ""playermain"",
            ""id"": ""cbb11d59-7f67-46c2-ac38-eb126db2e981"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""6ec839da-a5a8-4d12-9a84-44a8233dc75d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""ded78ab8-38ea-4f41-ab28-4d68c0aee5b7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0918f88-daac-48cd-9ebd-f7e85e67f07b"",
                    ""path"": ""<AndroidGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30e04777-9f86-4f92-9b13-138f171a58e5"",
                    ""path"": ""<Touchscreen>/touch0/radius"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""beccb53d-4ad1-46e2-9e33-05a4640ca6f2"",
                    ""path"": ""<AndroidGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c970bc45-f9f5-4a38-b0bc-62ffcd859d11"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playermain
        m_playermain = asset.FindActionMap("playermain", throwIfNotFound: true);
        m_playermain_move = m_playermain.FindAction("move", throwIfNotFound: true);
        m_playermain_look = m_playermain.FindAction("look", throwIfNotFound: true);
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

    // playermain
    private readonly InputActionMap m_playermain;
    private IPlayermainActions m_PlayermainActionsCallbackInterface;
    private readonly InputAction m_playermain_move;
    private readonly InputAction m_playermain_look;
    public struct PlayermainActions
    {
        private @Player m_Wrapper;
        public PlayermainActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_playermain_move;
        public InputAction @look => m_Wrapper.m_playermain_look;
        public InputActionMap Get() { return m_Wrapper.m_playermain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayermainActions set) { return set.Get(); }
        public void SetCallbacks(IPlayermainActions instance)
        {
            if (m_Wrapper.m_PlayermainActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_PlayermainActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_PlayermainActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_PlayermainActionsCallbackInterface.OnMove;
                @look.started -= m_Wrapper.m_PlayermainActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_PlayermainActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_PlayermainActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_PlayermainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
            }
        }
    }
    public PlayermainActions @playermain => new PlayermainActions(this);
    public interface IPlayermainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
