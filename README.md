# Trench
Free open source AI-friendly framework for code generation with Domain-Driven Design (DDD) architecture based on contracts.

**Objective**: Use a chatbot to generate complex applications or modules in a context controlled by a kernel. Ultimately, one of the generator interfaces will be the chatbot, but it will not be the only one. The advantage is that the result will be a component integrable into the company's systems.

To achieve this objective, we start with a framework that provides a working context facilitating the use of a chatbot by a programmer to obtain modules and/or applications for well-defined problems.

For this, we propose a technology-agnostic framework with a DDD architecture that facilitates the creation of application generation contexts, which we call "kernels".

At a glance, we will have a framework, a kernel, and end-user modules/applications.

The framework's mission is to provide all the technological infrastructure (databases, monitoring, traceability, exceptions, security, automatic testing) with different options (WPF, Angular, AutoMapper, Log4net, Docker, Unit).
This is achieved by:
- Separating the responsibilities of the framework, the kernel, and the application into five layers: Front-End, Application, Domain, Repository, and Testing.
- Separating within each layer the nature of each project into three types: Contracts (Interfaces responsible for ensuring quality and compatibility), Implementation (Code implementation), and Data (Since data is reused differently than code, it has its own project type).

This way, each dependency will always have:

A kernel, therefore, provides a context to create applications aimed at solving a domain of problems. Examples of kernels are:
- **Industrial Machine Vision**: Inspection points in factories to control the manufacturing process of a product. Considering that an artificial vision point can consist of one or several linear, 2D, or 3D cameras from one or several manufacturers with encoders, photoelectric cells, transmission bands, PLCs, robots or gantries, and various signal processing boards. In a kernel of this type, the main concept will be the camera.
- **ERP**: The organization of a company determines its differentiation; the flexibility of its ERP to adapt to its organization determines its survival. This is, without a doubt, a classic kernel in computing, and therefore, we will include different examples of integration or development. In a kernel of this type, the main concept will be "client."
- **Games**: Another typical area of computing where the capabilities of a computer can be pushed to the limit. In a kernel of this type, the main concept will be "player."

Lastly, once we have a technological framework and a business kernel, we can implement end-user applications. For example, for the machine vision kernel, we can create calibration utilities for the cameras whose manufacturers we want to consider. For the ERP, we can create applications for small or large companies where the complexity of the concepts can vary greatly depending on the size.
