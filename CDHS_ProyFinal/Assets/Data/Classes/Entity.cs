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

[RAYCAST]
- Distancia
- Capas
* Dibujar raycast
* Regresar resultado
	[RAYCAST BOX]
	- Tamaño "cubo"
	* Dibujar raycast de "cubo"
	* Regresar resultado de raycast "cubo"
	[RAYCAST SPHERE]
	- Radio esfera
	- Información
	* Dibujar raycast de esfera
	* Regresar resultado de raycast esfera
*/