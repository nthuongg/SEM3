const amqp = require("amqplib");
const queue = "t2210m";
async function sendMessage(data){
    try {
        const connection = await amqp.connect("amqp://localhost:5672");
        const channel = await connection.createChannel();
        process.once("SIGINT", async ()=>{
            await channel.close();
            await connection.close();
        })
        await channel.assertQueue(queue);
        await channel.sendToQueue(queue,Buffer.from(JSON.stringify(data)));
        console.log("Message sent....");
    } catch (error) {
        console.log(error);
    }
}

const express = require("express");
const app = express();
app.listen(3000,function(){
    console.log("App is running....");
})

app.get("/create-order", function(req,res){
    const data = {
        message: "Done",
        order_id: 15
    }
    sendMessage(data);
    res.send("done");
})