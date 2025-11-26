# 🍫 Vending Machine App

## 📋 Descripción

Aplicación de máquina expendedora (Vending Machine) desarrollada como ejemplo práctico de **Máquina de Estados Finitos** para la clase de Teoría de la Computación. El proyecto implementa una máquina de estados determinista que simula el comportamiento de una máquina expendedora real.

## 🎓 Concepto Teórico

Este proyecto es una implementación práctica de una **Máquina de Estados Finitos Determinista (DFA)** donde:

- **Estados (Q)**: Representan el balance actual de dinero (0-20) y estados especiales (dispensar producto, devolver cambio)
- **Alfabeto (Σ)**: Monedas (1, 2, 5, 10) y acciones (comprar A, comprar B, cancelar)
- **Función de Transición (δ)**: Lógica que procesa las entradas y cambia de estado
- **Estado Inicial (q₀)**: balance0 (sin dinero)
- **Estados Finales (F)**: dispenseA, dispenseB, returnChange

### Diagrama de Estados

```
┌─────────────┐
│  balance0   │ (Estado Inicial)
└──────┬──────┘
       │ Moneda (1,2,5,10)
       ▼
┌─────────────┐
│ balance1-20 │ (Estados de Balance)
└──────┬──────┘
       │
       ├─► Comprar A ($12) ──► dispenseA ──► balance0
       ├─► Comprar B ($15) ──► dispenseB ──► balance0
       └─► Cancelar ────────► returnChange ──► balance0
```

## 🏗️ Arquitectura

El proyecto sigue una **arquitectura limpia (Clean Architecture)** con separación de responsabilidades:

```
VendingMachineApp/
├── VendingMachineApp/              # Capa de Presentación (MAUI)
│   ├── Vistas/                     # Interfaces de usuario XAML
│   └── Presentacion/               # ViewModels (MVVM)
│
├── VendingMachineApp.Application/  # Capa de Aplicación
│   └── Interfaces/                 # Contratos de servicios
│
├── VendingMachineApp.Domain/       # Capa de Dominio
│   └── Entities/                   # Lógica de negocio pura
│       ├── StateMachine.cs         # Implementación de la máquina de estados
│       ├── States.cs               # Enumeración de estados
│       ├── Entrys.cs               # Enumeración de entradas
│       └── TransitionResult.cs     # Resultado de transiciones
│
└── VendingMachineApp.Infrastructure/ # Capa de Infraestructura
    └── Service/                     # Implementación de servicios
```

## 🔧 Tecnologías

- **.NET MAUI** - Framework multiplataforma para la interfaz de usuario
- **C# 10+** - Lenguaje de programación
- **.NET 10.0** - Framework base
- **MVVM Pattern** - Patrón de diseño para la UI

## 📊 Estados del Sistema

| Estado | Valor | Descripción |
|--------|-------|-------------|
| balance0-20 | 0-20 | Representa el balance actual en la máquina |
| dispenseA | 21 | Estado de dispensar producto A |
| dispenseB | 22 | Estado de dispensar producto B |
| returnChange | 23 | Estado de devolver cambio |
| Error | 99 | Estado de error |

## 🎮 Entradas Válidas

| Entrada | Descripción | Acción |
|---------|-------------|--------|
| Coin1 | Moneda de $1 | Incrementa balance en 1 |
| Coin2 | Moneda de $2 | Incrementa balance en 2 |
| Coin5 | Moneda de $5 | Incrementa balance en 5 |
| Coin10 | Moneda de $10 | Incrementa balance en 10 |
| buttonBuyA | Botón comprar A | Compra producto A ($12) |
| buttonBuyB | Botón comprar B | Compra producto B ($15) |
| buttonCancel | Botón cancelar | Devuelve el dinero |

## 🎯 Reglas de Negocio

1. **Balance máximo**: 20 unidades monetarias
2. **Producto A**: Cuesta $12
3. **Producto B**: Cuesta $15
4. **Validaciones**:
   - No se puede exceder el balance máximo
   - No se puede comprar sin saldo suficiente
   - Al cancelar, se devuelve todo el balance
   - Después de comprar o cancelar, se resetea a balance0

## 🚀 Cómo Ejecutar

### Prerrequisitos

- Visual Studio 2022 (versión 17.8 o superior)
- Carga de trabajo de .NET MAUI
- SDK de .NET 10.0

### Pasos

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/ErickGarciaX/VendingMachineApp.git
   cd VendingMachineApp
   ```

2. **Abrir la solución**:
   ```bash
   start VendingMachineApp.slnx
   ```

3. **Seleccionar plataforma objetivo**:
   - Windows
   - Android
   - iOS
   - macOS

4. **Ejecutar**:
   - Presionar F5 o hacer clic en el botón de ejecutar

## 💻 Ejemplo de Uso

```csharp
// Crear instancia de la máquina
var machine = new StateMachine();

// Estado inicial
Console.WriteLine(machine.CurrentState); // balance0

// Insertar moneda de $10
var result = machine.ProcessEntry(Entrys.Coin10);
Console.WriteLine(machine.CurrentState); // balance10

// Insertar moneda de $5
result = machine.ProcessEntry(Entrys.Coin5);
Console.WriteLine(machine.CurrentState); // balance15

// Comprar producto B ($15)
result = machine.ProcessEntry(Entrys.buttonBuyB);
Console.WriteLine(result.Message); // "Producto entregado."
Console.WriteLine(machine.CurrentState); // dispenseB

// Reset automático
machine.Reset();
Console.WriteLine(machine.CurrentState); // balance0
```

## 🧪 Casos de Prueba

### Caso 1: Compra exitosa
- **Entrada**: Coin10 → Coin2 → buttonBuyA
- **Resultado**: balance10 → balance12 → dispenseA → balance0

### Caso 2: Saldo insuficiente
- **Entrada**: Coin5 → buttonBuyA
- **Resultado**: balance5 → Error: "Monto Insuficiente"

### Caso 3: Exceder balance máximo
- **Entrada**: Coin10 → Coin10 → Coin5
- **Resultado**: balance10 → balance20 → Error: "Monto maximo es de 20"

### Caso 4: Cancelar compra
- **Entrada**: Coin10 → Coin5 → buttonCancel
- **Resultado**: balance10 → balance15 → returnChange → balance0

## 📚 Conceptos de Teoría de la Computación

Este proyecto demuestra:

1. **Determinismo**: Para cada estado y entrada, existe una única transición definida
2. **Completitud**: Todas las entradas válidas están definidas para cada estado
3. **Transiciones**: Implementadas mediante la función `ProcessEntry()`
4. **Estados Finales**: Tras alcanzar estados de dispensado o devolución, se retorna al estado inicial
5. **Validación de Entradas**: Rechaza entradas inválidas o que violan reglas de negocio

## 👨‍💻 Autor

**Erick Garcia**
- GitHub: [@ErickGarciaX](https://github.com/ErickGarciaX)
**Eduardo Gómez**
- GitHub: [@EduardoGMora](https://github.com/EduardoGMora)

## 📄 Licencia

Este proyecto es un trabajo académico para la clase de Teoría de la Computación.

---

**Nota**: Este proyecto es un ejemplo educativo que demuestra cómo los conceptos teóricos de máquinas de estados se aplican en aplicaciones del mundo real.