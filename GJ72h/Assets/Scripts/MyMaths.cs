using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public static class MyMaths
{
            
    public static float Scal_Coordonnes(float x1, float x2, float y1, float y2)
    {
        return x1 * x2 + y1 * y2;
    }

    public static float Scal_Angle(float normeV1, float normeV2, float angle)
    {
        return normeV1 * normeV2 * Mathf.Cos(angle);
    }

    public static float Scal_AngleDegree(float normeV1, float normeV2, float angle)
    {
        return normeV1 * normeV2 * Mathf.Cos(angle * Mathf.PI / 180.0f);
    }
    public static float RadToDegree(float radians)
    {
        return radians * (180.0f / Mathf.PI);
    }
    public static float CalcNorme(float x, float y)
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public static float CalcAngle(float x1, float y1, float x2, float y2)
    {
        float scalaire = Scal_Coordonnes(x1, x2, y1, y2);
        float norme1 = CalcNorme(x1, y1);
        float norme2 = CalcNorme(x2, y2);
        
        return RadToDegree(Mathf.Acos(scalaire / (norme1 * norme2)));
    }

    public static float CalDistance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }

    public static bool IsOnVisibleZone(Vector3 playerPosition, Vector3 ennemiPosition, float angle)
    {
        Vector2 playerPos = new Vector2(playerPosition.x, playerPosition.z);
        Vector2 ennemiPos = new Vector2(ennemiPosition.x, ennemiPosition.z);
        return IsOnVisibleZone(playerPos, ennemiPos, angle);
    }
    
    public static bool IsOnVisibleZone(Vector2 myPos, Vector2 targetPos, float angle)
    {
        Vector2 enemyLocalPosition = targetPos - myPos;
        float anglePlayerEnnemi = CalcAngle(enemyLocalPosition.x,
                                            enemyLocalPosition.y,
                                            1,
                                            0);
        
        float notInVision = (180 - angle) / 2;
        if (anglePlayerEnnemi > notInVision && anglePlayerEnnemi < 180 - notInVision)
        {
            float scal = Scal_Coordonnes(enemyLocalPosition.x,
                                         0,
                                         enemyLocalPosition.y,
                                         1);

            if (scal > 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsOnVisibleZone(Vector3 playerPosition, Vector3 ennemiPosition, float angle, float offsetAngleY)
    {
        Vector2 playerPos = new Vector2(playerPosition.x, playerPosition.z);
        Vector2 ennemiPos = new Vector2(ennemiPosition.x, ennemiPosition.z);
        return IsOnVisibleZone(playerPos, ennemiPos, angle, offsetAngleY);
    }

    public static bool IsOnVisibleZone(Vector2 myPos, Vector2 targetPos, float angle, float offsetAngleY, bool WantDebug = false)
    {
        Vector2 enemyLocalPosition = targetPos - myPos;
        float anglePlayerEnnemi = CalcAngle(enemyLocalPosition.x,
            enemyLocalPosition.y,
            1,
            0);
        
        float notInVision = (180 - angle) / 2;
        
                    
        float scal = Scal_Coordonnes(enemyLocalPosition.x,
            0,
            enemyLocalPosition.y,
            1);

        if (scal < 0)
        {
            anglePlayerEnnemi = 360 - anglePlayerEnnemi;
        }

        if (WantDebug)
        {
            Debug.Log("scal: " + scal);
            Debug.Log("anglePlayerEnnemi: " + anglePlayerEnnemi);
            Debug.Log("notInVision: " + notInVision);
            Debug.Log("offsetAngleY: " + offsetAngleY);
            Debug.Log("Min range: " + (notInVision - offsetAngleY) + " Max range: " + ((180 - notInVision) - offsetAngleY));
        }
        
        //if (anglePlayerEnnemi > notInVision && anglePlayerEnnemi < 180 - notInVision)
        bool isInVision = IsAngleInRange(anglePlayerEnnemi, notInVision - offsetAngleY, (180 - notInVision) - offsetAngleY);
        if (isInVision)
        {

            if (scal > 0)
            {
            }
            return true;
        }
        return false;
    }
    
    
    // Fonction pour convertir un angle en degrés en un vecteur2
    public static Vector2 AngleToVector(float angleDegrees)
    {
        // Convertir l'angle en radians
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        // Calculer les composantes x et y du vecteur en utilisant les fonctions trigonométriques
        float x = Mathf.Cos(angleRadians);
        float y = Mathf.Sin(angleRadians);

        // Retourner le vecteur2 résultant
        return new Vector2(x, y);
    }
    
    
    // Fonction pour vérifier si un angle est dans une plage d'angles spécifiée
    public static bool IsAngleInRange(float angle, float startAngle, float endAngle)
    {
        // Normaliser les angles pour les ramener dans la plage [0, 360)
        angle = NormalizeAngle(angle);
        startAngle = NormalizeAngle(startAngle);
        endAngle = NormalizeAngle(endAngle);

        // Si l'intervalle est entièrement contenu dans une plage de 0 à 360
        if (startAngle <= endAngle)
        {
            return angle >= startAngle && angle <= endAngle;
        }
        else // Si l'intervalle traverse le point 0
        {
            return angle >= startAngle || angle <= endAngle;
        }
    }

    // Fonction pour normaliser un angle dans la plage [0, 360)
    public static float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle < 0f)
        {
            angle += 360f;
        }
        return angle;
    }
    
}
