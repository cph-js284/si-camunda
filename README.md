# si-camunda
Handin for camunda assignment

# What is it
This is a repo containing a C# (dotnet core 3.0) project.
The project contains 6 externaltask-handlers (located in the Handlers-folder). The server hosting the handlers will query camunda for tasks specific to these 6 handlers and perform the work should a task be available.
<br>
<br>
The repo also contains the model XML-file camundaCarRental.bpmn. This file can be loading into the modeler and from there deployed to camunda.
<br>
<b>Requirements: docker must be installed on your machine.<b>
<br>

# How to make it go

1) Pull and run camunda from the docker hub by executing
```
sudo docker run -d --name camunda -p 8080:8080 camunda/camunda-bpm-platform:latest
```
2) Pull and run the image containing the camundaworker from docker hub by executing:
```
sudo docker run --name camundaworker --link camunda cphjs284/camundaworker
```
NB. The server queries camunda every 10 secs which creates quite a bit of console spam.
3) Open your camunda modeler and navigate to the camundaCarRental.bpmn in this repo.
4) Deploy diagram to camunda
5) open browser and navigate to camunda startpage
```
http://localhost:8080/camunda-welcome/index.html (credentials: demo/demo)
```
6) navigate to welcomescreen -> cockpit -> Tasklist -> start process and choose CarRental process
7) Click link "All Tasks", the first tasks in the rentalprocess will be to "query available cars"