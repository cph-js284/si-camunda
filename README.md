# si-camunda
Handin for camunda assignment

# What is it
This is a repo containing a C# (dotnet core 3.0) project.
The project contains 6 externaltask-handlers (located in the Handlers-folder). The server hosting the handlers will query camunda for tasks specific to these 6 handlers and perform the work should a task be available.
<br>
<br>
The repo also contains the model XML-file camundaCarRental.bpmn. This file can be loading into the modeler and from there deployed to camunda.
<br>
<b>Requirements: docker must be installed on your machine.</b>
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

3) Open your camunda modeler and deploy both the model(camundaCarRental.bpmn) and the rule-engine(DecisionTable1.dmn) to camunda.

4) open browser and navigate to camunda startpage (credentials: demo/demo)

```
http://localhost:8080/camunda-welcome/index.html 
```

5) navigate to welcomescreen -> Tasklist -> start process and choose CarRental process
6) Click link "All Tasks", the first tasks in the rentalprocess will be to "query available cars" (the process has not been assigned to any specific user, so you must claim the task before you can move the proccess forward).

# Cleanup
```
sudo docker rm -f camundaworker
sudo docker rm -f camunda
```
