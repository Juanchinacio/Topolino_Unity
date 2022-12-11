using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fulleto_Tapon_Controller : MonoBehaviour
{
    #region Variables Publicas

    #endregion

    #region Variables Privadas
    // Declaracion BT
    private BehaviourTreeEngine bt;

    // Percepciones
    public bool esTopolinoCerca = true;
    public bool esTopolinoVisto = true;
    #endregion

    void Start()
    {
        // Creacion behaviour tree
        bt = new BehaviourTreeEngine();

        // Percepciones
        Perception percepcion_EsTopolinoCerca = bt.CreatePerception<ValuePerception>(() => esTopolinoCerca);
        Perception percepcion_EsTopolinoVisto = bt.CreatePerception<ValuePerception>(() => esTopolinoVisto);
        Perception percepcion = bt.CreatePerception<ValuePerception>(() => esTopolinoVisto == true);
        // Acciones
        LeafNode accion_Patrullo = bt.CreateLeafNode("patrullo", Patrullo, AlwaysSucceed);
        LeafNode accion_Grito = bt.CreateLeafNode("grito", Grito, AlwaysSucceed);
        LeafNode accion_Persigo = bt.CreateLeafNode("persigo", Persigo, AlwaysSucceed);
        LeafNode accion_Ataco = bt.CreateLeafNode("ataco", Ataco, AlwaysSucceed);
        LeafNode accion_Busco = bt.CreateLeafNode("busco", Busco, AlwaysSucceed);

        // Secuencias
        SequenceNode secuencia_VeoTopolino = bt.CreateSequenceNode("seq_VeoTopolino", false);
        SequenceNode secuencia_GritoAlerta = bt.CreateSequenceNode("seq_GritoAlerta", false);
        SequenceNode secuencia_QueHago = bt.CreateSequenceNode("seq_QueHago", false);

        // Condiciones
        ConditionalDecoratorNode condicion_EsTopolinoVisto_0 = bt.CreateConditionalNode("esVisto_0", secuencia_VeoTopolino, percepcion_EsTopolinoVisto);
        ConditionalDecoratorNode condicion_EsTopolinoCerca_0 = bt.CreateConditionalNode("esCerca_0", accion_Persigo, percepcion_EsTopolinoCerca);
        ConditionalDecoratorNode condicion_EsTopolinoVisto_1 = bt.CreateConditionalNode("esVisto_1", accion_Busco, percepcion_EsTopolinoVisto);
        ConditionalDecoratorNode condicion_EsTopolinoCerca_1 = bt.CreateConditionalNode("esCerca_1", accion_Ataco, percepcion_EsTopolinoCerca);

        // Bucle
        //LoopDecoratorNode buclePrincipal = bt.CreateLoopNode("buclePrincipal", condicion_EsTopolinoVisto_0);

        // Coneccion de nodos
        //   - Rellenado de secuencias
        secuencia_VeoTopolino.AddChild(condicion_EsTopolinoVisto_0);
        secuencia_VeoTopolino.AddChild(secuencia_GritoAlerta);

        secuencia_GritoAlerta.AddChild(accion_Grito);
        secuencia_GritoAlerta.AddChild(secuencia_QueHago);

        secuencia_QueHago.AddChild(condicion_EsTopolinoCerca_0);
        secuencia_QueHago.AddChild(condicion_EsTopolinoCerca_1);
        secuencia_QueHago.AddChild(condicion_EsTopolinoVisto_1);

        LoopDecoratorNode buclePrincipal = bt.CreateLoopNode("buclePrincipal", condicion_EsTopolinoVisto_0);


        bt.SetRootNode(buclePrincipal);
    }

    void Update()
    {
        bt.Update();
    }

    #region Acciones
    void Patrullo()
    {
        Debug.Log("Patrullo");
    }
    void Grito() 
    {
        Debug.Log("Grito");
    }
    void Persigo()
    {
        Debug.Log("Persigo");
    }
    void Ataco()
    {
        Debug.Log("Ataco");
    }
    void Busco()
    {
        Debug.Log("Busco");
    }
    #endregion

    #region Percepciones
    public void topolinoCerca()
    {
        esTopolinoCerca = true;
    }
    public void topolinoNoCerca()
    {
        esTopolinoCerca = false;
    }
    public void topolinoVisto()
    {
        esTopolinoVisto = true;
    }
    public void topolinoNoVisto()
    {
        esTopolinoVisto = false;
    }
    #endregion

    private ReturnValues AlwaysSucceed()
    {
        return ReturnValues.Succeed;
    }
    private ReturnValues AlwaysFailed()
    {
        return ReturnValues.Failed;
    }
}
