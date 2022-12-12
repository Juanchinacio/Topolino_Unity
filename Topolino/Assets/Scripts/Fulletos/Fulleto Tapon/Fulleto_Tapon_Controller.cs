using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Fulleto_Tapon_Controller : MonoBehaviour
{
    #region Variables Publicas

    #endregion

    #region Variables Privadas
    //// Declaracion BT
    //private BehaviourTreeEngine bt;
    //
    //// Percepciones
    //public bool esTopolinoCerca = true;
    //public bool esTopolinoVisto = true;
    #endregion

    void Start()
    {
        // Creacion behaviour tree
        // = new BehaviourTreeEngine();
        //
        // Percepciones
        //rception percepcion_EsTopolinoCerca = bt.CreatePerception<ValuePerception>(() => esTopolinoCerca);
        //rception percepcion_EsTopolinoVisto = bt.CreatePerception<ValuePerception>(() => esTopolinoVisto);
        //rception percepcion = bt.CreatePerception<ValuePerception>(() => esTopolinoVisto == true);
        // Acciones
        //afNode accion_Patrullo = bt.CreateLeafNode("patrullo", Patrullo, AlwaysSucceed);
        //afNode accion_Grito = bt.CreateLeafNode("grito", Grito, AlwaysSucceed);
        //afNode accion_Persigo = bt.CreateLeafNode("persigo", Persigo, AlwaysSucceed);
        //afNode accion_Ataco = bt.CreateLeafNode("ataco", Ataco, AlwaysSucceed);
        //afNode accion_Busco = bt.CreateLeafNode("busco", Busco, AlwaysSucceed);
        //
        // Secuencias
        //quenceNode secuencia_VeoTopolino = bt.CreateSequenceNode("seq_VeoTopolino", false);
        //quenceNode secuencia_GritoAlerta = bt.CreateSequenceNode("seq_GritoAlerta", false);
        //quenceNode secuencia_QueHago = bt.CreateSequenceNode("seq_QueHago", false);
        //
        // Condiciones
        //nditionalDecoratorNode condicion_EsTopolinoVisto_0 = bt.CreateConditionalNode("esVisto_0", secuencia_VeoTopolino, percepcion_EsTopolinoVisto);
        //nditionalDecoratorNode condicion_EsTopolinoCerca_0 = bt.CreateConditionalNode("esCerca_0", accion_Persigo, percepcion_EsTopolinoCerca);
        //nditionalDecoratorNode condicion_EsTopolinoVisto_1 = bt.CreateConditionalNode("esVisto_1", accion_Busco, percepcion_EsTopolinoVisto);
        //nditionalDecoratorNode condicion_EsTopolinoCerca_1 = bt.CreateConditionalNode("esCerca_1", accion_Ataco, percepcion_EsTopolinoCerca);
        //
        // Bucle
        //LoopDecoratorNode buclePrincipal = bt.CreateLoopNode("buclePrincipal", condicion_EsTopolinoVisto_0);
        //
        // Coneccion de nodos
        //   - Rellenado de secuencias
        //cuencia_VeoTopolino.AddChild(condicion_EsTopolinoVisto_0);
        //cuencia_VeoTopolino.AddChild(secuencia_GritoAlerta);
        //
        //cuencia_GritoAlerta.AddChild(accion_Grito);
        //cuencia_GritoAlerta.AddChild(secuencia_QueHago);
        //
        //cuencia_QueHago.AddChild(condicion_EsTopolinoCerca_0);
        //cuencia_QueHago.AddChild(condicion_EsTopolinoCerca_1);
        //cuencia_QueHago.AddChild(condicion_EsTopolinoVisto_1);
        //
        //opDecoratorNode buclePrincipal = bt.CreateLoopNode("buclePrincipal", condicion_EsTopolinoVisto_0);
        //
        //
        //.SetRootNode(buclePrincipal);
    }

    void Update()
    {
        //bt.Update();
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
        //esTopolinoCerca = true;
    }
    public void topolinoNoCerca()
    {
        //esTopolinoCerca = false;
    }
    public void topolinoVisto()
    {
        //esTopolinoVisto = true;
    }
    public void topolinoNoVisto()
    {
        //esTopolinoVisto = false;
    }
    #endregion

    //private ReturnValues AlwaysSucceed()
    //{
    //    return ReturnValues.Succeed;
    //}
    //private ReturnValues AlwaysFailed()
    //{
    //    return ReturnValues.Failed;
    //}
}
