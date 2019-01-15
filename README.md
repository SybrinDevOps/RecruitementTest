## 1. Welcome  
Welcome to the DevOps recruitment test. In this test you are given an incomplete project.    
To ensure we can see the progress you make please paste the given identifier in the following section:  
    ![guid](https://github.com/SybrinDevOps/RecruitementTest/tree/master/images/guid.png)  
Your goals are as follows:  
## 2. Solution Breakdown
* Result Application = Node.js    
* Vote Application = Python    
* Worker Application = .NET    
* Cache Management = Redis    
* Storage = MySQL    
  
## 2.1. Setup the solution    
* The solution required will be:    
    * A web-based voting application with two options (Intel vs. AMD)    
    * Every vote is processed by the application    
    * Cached to Redis    
    * Saved to MySQL    
    * Button to generate a report on all votes the system received    
* Steps to follow:    
    * Get all the parts running locally  
    * Move all components to containers  
    * Enable cross container communication  
    * Test the solution  
* Containerize the solution (links added to get you going)  
    * Docker Basics: [Link](https://medium.freecodecamp.org/a-beginner-friendly-introduction-to-containers-vms-and-docker-79a9e3e119b)
    * Containerizing .NET: [Link](https://docs.docker.com/engine/examples/dotnetcore/#prerequisites)  
    * Containerizing Jenkins: [Link](https://github.com/jenkinsci/docker/blob/master/README.md)  
    * Containerizing Redis: [Link](https://hub.docker.com/_/redis)  
    * Containerizing Node: [Link](https://nodejs.org/en/docs/guides/nodejs-docker-webapp/)  
* Automate the deployment of the solution  
    * Jenkins should be used for managing your containers and building the solution  
   
## 3. Notes

* You may choose how to containerize the solution  
* Redis connection string will look similar to this:   
    ```localhost, connectTimeout=5000, syncTimeout=5000```  
* Use container-based Jenkins  
* Make On  
  
  