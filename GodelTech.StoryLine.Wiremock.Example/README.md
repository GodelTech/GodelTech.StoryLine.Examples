# GodelTech.StoryLine.Wiremock.Example

## Overview

**GodelTech.StoryLine.Wiremock.Example** contains the following solutions:
* **GodelTech.StoryLine.Wiremock.Example** contains implementation of simple REST microservice which provides proxy\routing logic for user and document functionality. 
* **GodelTech.StoryLine.Wiremock.Example.SubSystemTests** contains subsystem tests written with help of **StoryLine.Rest** and **StoryLine.Wiremock** libraries. 

**NOTE**: You may need to install [Docker](https://www.docker.com/) in order to run Wiremock tool. Alternatively you may install Wiremock as stand alone application but this approach may be more complicated.

In order to run tests successfully the follection actions must be performed:
* Build **GodelTech.StoryLine.Wiremock.Example** solution.
* Run **GodelTech.StoryLine.Wiremock.Example** microservice.
* Create Docker container running Wiremock. Use `run-wiremock.bat` located in root of Examples folder.
* Build **GodelTech.StoryLine.Wiremock.Example.SubSystemTests** solution.
* Run tests included in **GodelTech.StoryLine.Wiremock.Example.SubSystemTests**.

Subsystem tests performs validation proxying\roting logic implemented by gateway microservice. Tests attempt invoke all operations and verify the results match expectations.