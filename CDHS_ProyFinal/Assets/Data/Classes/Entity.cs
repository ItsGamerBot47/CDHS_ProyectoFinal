using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private EntityData entityInfo;
}

/*
[ENTIDAD]
- Identificador
	[PERSONA]
	- Nombre
		[ENEMIGO]
		- Vida Individual
		- Puntaje
		[JUGADOR]
		- Apodo
	[OBJETO]
	- Tipo Objeto
		[ITEM]
		- Alterar vida jugador
		[POTENCIADOR]
		- Tipo Potenciador
		- Efecto
*/