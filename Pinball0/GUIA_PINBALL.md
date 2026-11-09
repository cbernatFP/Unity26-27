# Guia: Pinball molt senzill (Pinball0)

Aquest projecte ja ve **muntat** (obre `Assets/Scenes/SampleScene.unity` i dóna-li al Play).
Aquesta guia explica com està fet i **com ho podries construir tu a mà a l'editor**, fent servir
només els coneixements del projecte *Balls*: sprites Square i Circle, Rigidbody2D, Collider2D i
un material físic que rebota.

---

## La idea

- Una **caixa** feta amb 4 parets (sprites *Square*) que tanquen la zona visible de la càmera.
- A dalt, **fora de càmera**, un **tub** (2 parets verticals) amb una **bola** a dins.
- Quan comença el joc, la bola cau tota sola (té gravetat) i entra a la caixa per un forat del sostre.
- A dins hi ha **rampes** (dues per banda), un **pic central** en forma de ∧ i diversos **bumpers en X** perquè la bola reboti.
- Hi ha unes **boles diana** estàtiques de color groc. Quan la bola protagonista (**vermella**) les toca, **es destrueixen**.
- El **terra té un forat al mig** perquè la bola s'escapi (com el desaigüe d'un pinball de veritat).

## Organització en "carpetes" (GameObjects buits)

Els objectes estan agrupats dins de **GameObjects buits** que fan de carpetes, per tenir la *Hierarchy* ordenada:

- **Parets** → les 4 parets de la caixa (el terra partit en dos), el sostre i el tub.
- **Obstacles** → les rampes, el pic central i els bumpers en X.
- **Dianes** → les 8 boles diana grogues.
- La **BolaProtagonista** i la **Main Camera** queden soltes a l'arrel.

Per fer-ho tu: `GameObject → Create Empty`, poses-li el nom (per exemple *Parets*), el deixes a posició
`(0, 0, 0)` i després **arrossegues** els objectes a dins seu dins la finestra *Hierarchy*.
Important: si el GameObject buit està a `(0,0,0)` sense girar ni escalar, els fills no es mouen de lloc.

---

## 1. La càmera

La càmera ja és **Orthographic** amb **Size = 5**, posada a `(0, 0, -10)`.
Això fa que es vegi des de `y = -5` fins a `y = +5`. La caixa es construeix dins d'aquest marge.

## 2. Com fer una paret (això ja ho saps del Balls)

1. `GameObject → 2D Object → Sprites → Square`.
2. Al **Transform** poses la **posició**, l'**escala** (per fer-la llarga/estreta) i la **rotació Z** (per inclinar-la).
3. `Add Component → Box Collider 2D`.
4. (No cal Rigidbody2D: un sprite amb collider i **sense** Rigidbody2D ja és una paret estàtica.)

> Les rampes i els bumpers són exactament el mateix que una paret: un *Square* amb Box Collider 2D,
> però **girat** amb la rotació Z.

### Totes les peces (Square + Box Collider 2D)

| Nom            | Posició (X, Y)   | Escala (X, Y)  | Rotació Z | Color    |
|----------------|------------------|----------------|-----------|----------|
| ParetEsquerra  | (-4, 0)          | (0.25, 10)     | 0         | blau     |
| ParetDreta     | (4, 0)           | (0.25, 10)     | 0         | blau     |
| TerraEsquerra  | (-2.325, -4.85)  | (3.65, 0.25)   | 0         | blau     |
| TerraDret      | (2.325, -4.85)   | (3.65, 0.25)   | 0         | blau     |
| SostreEsquerra | (-1.3, 4.85)     | (5.1, 0.25)    | 0         | blau     |
| SostreDret     | (2.95, 4.85)     | (1.8, 0.25)    | 0         | blau     |
| TubEsquerra    | (1.2, 6.5)       | (0.2, 4)       | 0         | blau     |
| TubDret        | (2.1, 6.5)       | (0.2, 4)       | 0         | blau     |
| RampaEsq1      | (-2.6, 2.6)      | (2.2, 0.22)    | -25       | taronja  |
| RampaEsq2      | (-2.6, 0.0)      | (2.2, 0.22)    | -25       | taronja  |
| RampaDreta1    | (2.6, 1.6)       | (2.2, 0.22)    | 25        | taronja  |
| RampaDreta2    | (2.6, -1.0)      | (2.2, 0.22)    | 25        | taronja  |
| Pic_Esq        | (-0.55, -1.0)    | (1.6, 0.22)    | 35        | verd     |
| Pic_Dret       | (0.55, -1.0)     | (1.6, 0.22)    | -35       | verd     |
| X1_A           | (-2.2, -3.3)     | (1.3, 0.22)    | 45        | verd     |
| X1_B           | (-2.2, -3.3)     | (1.3, 0.22)    | -45       | verd     |
| X2_A           | (0.0, -2.8)      | (1.3, 0.22)    | 45        | verd     |
| X2_B           | (0.0, -2.8)      | (1.3, 0.22)    | -45       | verd     |
| X3_A           | (2.2, -3.3)      | (1.3, 0.22)    | 45        | verd     |
| X3_B           | (2.2, -3.3)      | (1.3, 0.22)    | -45       | verd     |

> **El sostre té un forat** entre `x = 1.25` i `x = 2.05` (entre SostreEsquerra i SostreDret).
> Per aquest forat és per on cau la bola des del tub.
>
> **El terra també té un forat** entre `x = -0.5` i `x = 0.5` (entre TerraEsquerra i TerraDret).
> Per aquí s'escapa la bola i surt de la pantalla.
> El **tub** són dues parets verticals (TubEsquerra i TubDret) a `y = 6.5`, fora de càmera (per sobre de y=5).
>
> El **Pic** (Pic_Esq + Pic_Dret) està centrat a `x = 0` i forma un ∧ (teulada). Es fa així, en comptes
> d'una V, perquè la bola rellisca cap als costats i **no es queda atrapada** al mig.

Per canviar el **color** d'una peça: selecciona-la i al component **Sprite Renderer → Color**.

## 3. Les boles diana (es destrueixen)

Són sprites **Circle** estàtics, **grocs** i **petits**. Per cada una:

1. `GameObject → 2D Object → Sprites → Circle`.
2. Transform: escala `(0.45, 0.45)`, posició segons la taula.
3. `Add Component → Circle Collider 2D`. (Sense Rigidbody2D → estàtica.)
4. Color groc al **Sprite Renderer**.
5. **Molt important:** posa-li l'etiqueta **Tag = `Diana`** (a dalt de l'Inspector, desplegable *Tag*).
   L'etiqueta `Diana` ja està creada a `Project Settings → Tags and Layers`.

| Nom    | Posició (X, Y)  |
|--------|-----------------|
| Diana1 | (0.0, 3.5)      |
| Diana2 | (-3.3, 3.8)     |
| Diana3 | (3.3, 3.5)      |
| Diana4 | (0.0, 1.3)      |
| Diana5 | (-3.4, 1.3)     |
| Diana6 | (3.4, 0.3)      |
| Diana7 | (-1.3, -2.2)    |
| Diana8 | (1.3, -2.2)     |

## 4. El material que rebota

A `Assets/Materials/Rebot.physicsMaterial2D`:
- **Friction = 0.3**
- **Bounciness = 0.8**

(Es crea amb `clic dret a Project → Create → 2D → Physics Material 2D`, igual que al Balls.)

## 5. La bola protagonista

1. `GameObject → 2D Object → Sprites → Circle`.
2. Transform: posició `(1.65, 7.3)` (dins el tub, fora de càmera), escala `(0.45, 0.45)`.
3. Color vermell al **Sprite Renderer**.
4. `Add Component → Rigidbody 2D` → deixa **Gravity Scale = 1** (així cau sola al començar).
   - Recomanat: **Collision Detection = Continuous** (perquè no travessi les parets fines anant ràpid).
5. `Add Component → Circle Collider 2D` → al camp **Material** arrossega-hi `Rebot` (perquè reboti).
6. `Add Component → DestructorBoles` (l'script de sota).

## 6. L'script `DestructorBoles.cs`

Va **a la bola protagonista**. És igual d'estil que el `Final.cs` del Balls, però només
destrueix els objectes amb l'etiqueta `Diana` (així no destrueix les parets ni les rampes):

```csharp
private void OnCollisionEnter2D(Collision2D objecteCollisionat)
{
    if (objecteCollisionat.gameObject.tag == "Diana")
    {
        contDianes++;
        Destroy(objecteCollisionat.gameObject);
        Debug.Log("Dianes destruides: " + contDianes);
    }
}
```

---

## Com funciona (resum del flux)

1. Dónes al **Play**.
2. La bola vermella, que és a dins del tub, **cau per la gravetat**.
3. Passa pel forat del sostre i entra a la caixa.
4. Rebota per les rampes, el pic central i els bumpers en X (gràcies al material **Rebot**).
5. Quan toca una **bola diana** groga, aquesta **desapareix** i es veu un missatge a la *Console*.
6. Al final la bola troba el **forat del terra** i s'escapa per sota de la pantalla.

## Idees per ampliar amb els alumnes

- Posar material **Rebot** també a les parets perquè la bola salti més.
- Afegir més dianes o canviar-les de lloc.
- Fer el tub més ample o més estret.
- Canviar `Bounciness` i veure com canvia el joc.
