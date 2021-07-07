# NotificationScheduler
Sample .Net Core API using Entity Framework

Before testing the API, create a local MS-SQL database called "NotificationScheduler"

Market values :      
0 : Denmark   
1 : Norway   
2 : Sweden    
3 : Finland    

Company Type values :                        
0 : small   
1 : medium   
2 : large    

To add a company make the following request :

Method : POST    
URL    : https://localhost:44361/notificationScheduler/CreateSchedule    
Body   :    

{    
        "ID" : "aad7a630-af1c-4952-9cb4-44b8b847859b",      
        "CompanyName" : "Company Finland2",     
        "CompanyNumber" : "0100000000",    
        "CompanyType" : "1",     
        "Market" : 1     
}     


Sample Output looks like :     

{    
    "companyId": "aad7a630-af1c-4952-9cb4-44b8b847859b",     
    "notifications": [    
        "09/07/2021",    
        "13/07/2021",    
        "18/07/2021",    
        "28/07/2021"    
    ]    
}   
