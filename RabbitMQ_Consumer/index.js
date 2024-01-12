const amqp = require("amqplib");
const queue = "t2210m";

async function connect() {
    try {
        const connection = await amqp.connect("amqp://localhost:5672");
        const channel = await connection.createChannel();
        await channel.assertQueue(queue);
        channel.consume(
            queue,
            (massage)=>{
                if(massage){
                    console.log(JSON.parse(massage.content));
                }
            }
        );
        console.log("Consumer is listening....");
    } catch (error) {
        console.log(error);
    }
}
connect();