package ma.cloud.producer.service;
import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.stereotype.Service;

@Service
public class KafkaConsumer {
    @KafkaListener(topics = "CLIENTS", groupId = "sample_consumer")
    public void onMessage(ConsumerRecord client) {
        System.out.println("Receiving client => " + client.value());
//        clientRepository.save(client);
    }
}
