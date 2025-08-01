# 📁 ArtherCore — Estructura de Carpetas

Este documento describe la estructura profesional del proyecto Unity basado en una simulación con robots. Cada carpeta cumple un rol claro para asegurar mantenibilidad, modularidad y escalabilidad.

---

## 🎨 `Art/`

Contiene todos los recursos visuales del juego.

- `Characters/`: Modelos, texturas y animaciones de personajes o robots.
- `Environment/`: Elementos visuales del entorno (terreno, edificios, vegetación).
- `Props/`: Objetos interactivos o decorativos del mundo.
- `UI/`: Imágenes, íconos y elementos gráficos de la interfaz.
- `Materials/`: Materiales físicos (Standard, URP, HDRP).

---

## 🔊 `Audio/`

Recursos de audio organizados por tipo.

- `Music/`: Pistas musicales del juego o menú.
- `SFX/`: Efectos de sonido (pasos, botones, motores, etc.).
- `Voices/`: Voces grabadas (si aplica).

---

## 🧠 `Code/`

Contiene toda la lógica del juego escrita en C#.

### `Global/`  
Código que afecta todo el proyecto.

- `Controllers/`: Scripts que orquestan sistemas globales (ej. `GameManager`, `AudioManager`).
- `Systems/`: Sistemas independientes como guardado, eventos o UI general.
- `Managers/`: Gestión de estados, nivel, flujo de juego.
- `Utilities/`: Extensiones, herramientas comunes o helpers.

### `Scene1/` y `Scene2/`  
Código específico para escenas individuales.

- `Controllers/`: Controladores de lógica específica (enemigos, puzzles, triggers).
- `UI/`: Controladores de interfaz o menús de esa escena.
- `Data/`: Contenedores de datos o estados de la escena.
- `Logic/`: Scripts que implementan comportamientos internos.

---

## 🧱 `Prefabs/`

Prefabricados organizados por alcance.

- `Global/`: Prefabs reutilizables en múltiples escenas (UI genérica, cámaras, managers).
- `Scene1/`, `Scene2/`: Prefabs exclusivos de esas escenas (robots, enemigos, triggers locales).

---

## 🎬 `Scenes/`

Escenas del proyecto, separadas por tipo.

- `Bootstrap/`:  
  Contiene `_Bootstrap.unity`, que inicializa sistemas globales (`GameManager`, `AudioManager`) y transiciona al menú. No es visible para el jugador.

- `Menu/`:  
  Escena `MainMenu.unity` donde el jugador accede a las opciones iniciales (iniciar simulación, ajustes, salir).

- `Scene1/`, `Scene2/`:  
  Escenas principales de simulación. Contienen lógica, entornos y gameplay únicos.

---

## 📦 `ScriptableObjects/`

Almacena ScriptableObjects, que encapsulan datos y configuraciones reutilizables.

- `Settings/`: Configuración general del juego (parámetros de simulación, control, dificultad).
- `Data/`: Datos estructurados como estadísticas de robots, descripciones, misiones.
- `SceneSpecific/`: ScriptableObjects usados únicamente en escenas individuales.

---

## ⚙️ `Settings/`

Contiene assets técnicos que controlan el comportamiento del motor Unity.

- `Input/`: Archivos del nuevo Input System (`InputActions.inputactions`).
- `Rendering/`: Configuraciones gráficas (URP Asset, Lighting, Quality).
- `Physics/`: Ajustes físicos globales del juego (gravedad, capas de colisión).

---

## 🎨 `Shaders/`

Contiene shaders personalizados para materiales o efectos visuales avanzados.

---

## 🖥️ `UI/`

Estructura visual y lógica de interfaz de usuario.

- `Screens/`: Pantallas completas (menú, pausa, ajustes).
- `Elements/`: Componentes reutilizables (botones, barras de vida, texto).
- `Layouts/`: Prefabs o estructuras de diseño de UI (canvas, grids, anchors).

---

## 📌 Notas Finales

- Toda esta estructura está pensada para proyectos de mediana a gran escala.
- Las carpetas pueden crecer con subniveles si una escena se vuelve compleja.
- Se recomienda mantener un `README.md` en cada carpeta principal con detalles locales si trabajas en equipo.

