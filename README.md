# IOET Exercise
IOET Exercise Payment Calculation

After analyzing the exercise, it was decided to apply a DDD, and the following classes were identified:

![UML class](https://user-images.githubusercontent.com/103289374/164787057-221dca11-f51b-4298-84b3-00b1b565bf5f.jpeg)


A solution was created using .net Core 3.1 that was structured as follows


![UML class1](https://user-images.githubusercontent.com/103289374/164787379-ee218c1a-6a9f-47ae-9ebc-f6aedbd15691.jpeg)

## PaymentCalculation
The application, domain and infrastructure layers were created as recommended by DDD. 

The necessary classes and interfaces were created in the domain (DomainModelLayer). 

The calculation of the payment was made in the class EmployeeDomainService.cs (CalculatePayment), in addition, linq was used to find the cost per hour indicated according to the day and time (CostPerHourRepository.cs)

![Capture](https://user-images.githubusercontent.com/103289374/164789666-9e0d09f1-301b-427c-b655-37fc7bed8c36.GIF)


In the infrastructure, a repository class was created that stores data in cache since there is no database (CostPerHourRepository.cs). Here the data of the cost per hour that could be read from a physical table was initialized.

Finally, in the application layer, a service was created that allows the calculation of payment to employees EmployeeService.cs.


![Capture4](https://user-images.githubusercontent.com/103289374/164790110-503bc2f9-8326-4cd3-8696-52dc656fd5f5.GIF)

## PaymentCalculation.Web (Web API)

It was decided to create a web API to be easily accessible by various types of clients. I also use in this layer dependency injection (Startup.cs).

![Capture2](https://user-images.githubusercontent.com/103289374/164790519-5411e1ee-2e23-4803-95c6-999cb43a7567.GIF)

In the employee controller (EmployeeController.cs) the function for the query was registered

![Capture5](https://user-images.githubusercontent.com/103289374/164790845-cbe0ca33-dbe9-4c0b-ba61-6bd92d14b687.GIF)

## PaymentCalculation.ConsoleAPP

Finally a simple console project was created. Here the file is read and transformed into DTO objects with which the API is consulted (Program.cs)

![Capture6](https://user-images.githubusercontent.com/103289374/164791332-d3300f09-5560-49ef-a34c-3dfedfc44a8b.GIF)

## PaymentCalculation.Test

Additionally, unit tests were created for the EmployeeDomainService class that helped during development to test the calculation.

![Capture7](https://user-images.githubusercontent.com/103289374/164791673-5ae1ea41-5262-40ca-8478-33c716e87e0b.GIF)


# How to run

Make sure the PaymentCalculation.ConsoleAPP project is the main project and start it. In the console you will be asked to indicate the full path of the file you want to use. If you don't have a file, you can enter "./WorkedHours.txt" to use the attached file.

![console](https://user-images.githubusercontent.com/103289374/164792249-ad6094e8-f0b5-4ae2-b02a-345e93a930e6.PNG)

