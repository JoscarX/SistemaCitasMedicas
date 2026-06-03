# Sistema de Gestión de Citas Médicas

## Imagenes Prueba

<img width="985" height="522" alt="image" src="https://github.com/user-attachments/assets/05398efc-2878-4530-9629-6bc6b060e27b" />
<img width="986" height="519" alt="image" src="https://github.com/user-attachments/assets/867084aa-d64e-4099-a7ff-7ae5e3759506" />
<img width="986" height="517" alt="image" src="https://github.com/user-attachments/assets/d9f8e30e-31fc-4b65-8e5e-f61ed331b5af" />
<img width="1008" height="693" alt="image" src="https://github.com/user-attachments/assets/9b765baf-b99c-4baf-becd-6a0b085c45d6" />
<img width="1001" height="696" alt="image" src="https://github.com/user-attachments/assets/3ca63669-c509-4de4-9178-c19505da31dc" />
<img width="989" height="680" alt="image" src="https://github.com/user-attachments/assets/c0de9d2e-6534-4ce7-aec1-4a8bd993cbde" />
<img width="1030" height="692" alt="image" src="https://github.com/user-attachments/assets/48639b9f-77b5-4e17-8c38-d2c67403354c" />
<img width="993" height="688" alt="image" src="https://github.com/user-attachments/assets/98823f38-e7e8-42f5-8c52-fcaf6b37afd3" />
<img width="987" height="682" alt="image" src="https://github.com/user-attachments/assets/52fd7986-beb3-447e-947e-5bb0bd51d1ae" />
<img width="999" height="692" alt="image" src="https://github.com/user-attachments/assets/6282d077-c26f-41ba-9ea8-93325a7a1554" />
<img width="1015" height="706" alt="image" src="https://github.com/user-attachments/assets/4420d825-da2f-4d7f-bedc-0290ca467954" />



## Descripción

Aplicación de consola desarrollada en C# para la gestión de citas médicas de una clínica.

El sistema permite administrar pacientes, médicos, especialidades y citas médicas, aplicando principios de Programación Orientada a Objetos (POO) y buenas prácticas de diseño de software.

---

## Objetivo

Digitalizar el proceso de gestión de citas médicas para evitar problemas como:

- Citas duplicadas.
- Errores en cancelaciones.
- Dificultad para consultar disponibilidad.
- Información repetida.
- Falta de organización por especialidades.

---

## Funcionalidades

### Gestión de Pacientes

- Registrar pacientes.
- Consultar pacientes registrados.

### Gestión de Especialidades

- Registrar especialidades médicas.
- Consultar especialidades registradas.

### Gestión de Médicos

- Registrar médicos.
- Asignar médicos a especialidades.
- Consultar médicos registrados.

### Gestión de Citas

- Agendar citas médicas.
- Consultar citas.
- Cancelar citas.
- Reprogramar citas.

### Recordatorios

- Enviar recordatorios de citas mediante correo electrónico.
- Arquitectura preparada para soportar SMS, WhatsApp y otros canales en el futuro.

---

## Tecnologías Utilizadas

- C#
- .NET
- Programación Orientada a Objetos (POO)
- Consola de Windows

---

## Arquitectura del Proyecto

```text
SistemaCitasMedicas/
│
├── Models/
│   ├── Persona.cs
│   ├── Paciente.cs
│   ├── Medico.cs
│   ├── Especialidad.cs
│   ├── CitaMedica.cs
│   └── EstadoCita.cs
│
├── Interfaces/
│   └── INotificador.cs
│
├── Notifications/
│   ├── EmailNotificador.cs
│
├── Repositories/
│   ├── PacienteRepository.cs
│   ├── MedicoRepository.cs
│   ├── EspecialidadRepository.cs
│   └── CitaRepository.cs
│
├── Services/
│   ├── PacienteService.cs
│   ├── MedicoService.cs
│   ├── EspecialidadService.cs
│   ├── CitaService.cs
│   └── RecordatorioService.cs
│
├── Validators/
│   ├── ValidadorFecha.cs
│   └── ValidadorDisponibilidad.cs
│
└── Program.cs
```

---

## Principios Aplicados

### SOLID

#### Single Responsibility Principle (SRP)

Cada clase tiene una única responsabilidad.

Ejemplos:

- PacienteService administra pacientes.
- MedicoService administra médicos.
- CitaService administra citas.
- RecordatorioService administra recordatorios.

---

#### Open/Closed Principle (OCP)

El sistema está preparado para extender funcionalidades sin modificar el código existente.

Ejemplo:

Se pueden agregar nuevos tipos de notificaciones implementando la interfaz:

```csharp
INotificador
```

---

#### Liskov Substitution Principle (LSP)

Cualquier implementación de `INotificador` puede sustituir a otra.

Ejemplos:

- EmailNotificador
- SmsNotificador
- WhatsAppNotificador

---

#### Interface Segregation Principle (ISP)

Las interfaces contienen únicamente los métodos necesarios para cada responsabilidad.

---

#### Dependency Inversion Principle (DIP)

Los servicios dependen de abstracciones y no de implementaciones concretas.

---

### DRY (Don't Repeat Yourself)

Las validaciones reutilizables se encuentran centralizadas en:

- ValidadorFecha
- ValidadorDisponibilidad

---

### KISS (Keep It Simple)

Se implementó una solución simple utilizando almacenamiento en memoria mediante listas.

No se utilizaron tecnologías innecesarias para la primera versión.

---

### YAGNI (You Aren't Gonna Need It)

No se implementaron funcionalidades que aún no han sido solicitadas.

Funcionalidades excluidas:

- Facturación
- Historial clínico
- Seguros médicos
- Telemedicina
- Chat médico
- Inteligencia artificial

---

### SoC (Separation of Concerns)

Las responsabilidades se encuentran separadas en capas:

- Models
- Repositories
- Services
- Validators
- Notifications
- Interfaces

---

## Programación Orientada a Objetos

### Abstracción

Se utiliza la clase abstracta:

```csharp
Persona
```

De la cual heredan:

- Paciente
- Medico

---

### Herencia

```text
Persona
├── Paciente
└── Medico
```

---

### Polimorfismo

Implementado mediante la interfaz:

```csharp
INotificador
```

Con múltiples implementaciones:

- EmailNotificador
- SmsNotificador (Futura implementacion)
- WhatsAppNotificador (Futura implementacion)

---

### Encapsulamiento

Los datos son administrados mediante clases especializadas y servicios dedicados para cada módulo.

---

## Flujo General del Sistema

1. Registrar especialidades.
2. Registrar médicos.
3. Registrar pacientes.
4. Agendar citas.
5. Consultar citas.
6. Reprogramar o cancelar citas.
7. Enviar recordatorios.

---

## Almacenamiento de Datos

La aplicación utiliza almacenamiento temporal en memoria mediante colecciones `List<T>`.

Los datos permanecen disponibles mientras la aplicación se encuentre en ejecución.

---

## Posibles Mejoras Futuras

- Persistencia en SQL Server.
- Inicio de sesión.
- Gestión de usuarios y roles.
- Historial clínico.
- Facturación.
- Integración con correo real.
- Envío de SMS.
- Envío de WhatsApp.
- API REST.
- Interfaz gráfica.

---

## Autor 
Joscar Mota
Proyecto académico desarrollado como práctica de:

- Programación Orientada a Objetos
- Arquitectura de Software
- Principios SOLID
- Buenas Prácticas de Desarrollo

---
