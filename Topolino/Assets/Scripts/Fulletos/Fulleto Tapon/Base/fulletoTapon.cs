using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fulletoTapon : MonoBehaviour
{
    //private BehaviourTreeEngine bt;
    //
    //public bool veTopolino = false;
    //public bool topolinoCerca = false;
    //
    //void Start()
    //{
    //    // Create behaviour tree
    //    bt = new BehaviourTreeEngine();
    //
    //
    //    // Crear percepciones
    //    Perception topolinoCerca = bt.CreatePerception<ValuePerception>(() => 5 <= 0);
    //    Perception veTopolino = bt.CreatePerception<ValuePerception>(() => 5 <= 0);
    //
    //
    //
    //
    //
    //    // Create tree nodes
    //    SequenceNode mainSequence = bt.CreateSequenceNode("main sequence", false);
    //    LeafNode redNode = bt.CreateLeafNode("Red", RedAction, AlwaysSucceed);
    //    LeafNode blueNode = bt.CreateLeafNode("Blue", BlueAction, AlwaysSucceed);
    //    TimerDecoratorNode blueTimer = bt.CreateTimerNode("blue timer", blueNode, 1);
    //    ConditionalDecoratorNode condicion = bt.CreateConditionalNode("pepe", redNode, topolinoCerca);
    //
    //    // Connect nodes
    //    mainSequence.AddChild(redNode);
    //    mainSequence.AddChild(blueTimer);
    //    bt.SetRootNode(mainSequence);
    //}
    //
    //void Update()
    //{
    //    bt.Update();
    //}
    //private void RedAction()
    //{
    //    GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    //}
    //private void BlueAction()
    //{
    //    GetComponent<Renderer>().material.color = new Color(0, 0, 255);
    //}
    //private ReturnValues AlwaysSucceed()
    //{
    //    return ReturnValues.Succeed;
    //}
}
