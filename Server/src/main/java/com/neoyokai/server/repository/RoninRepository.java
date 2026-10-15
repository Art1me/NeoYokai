package com.neoyokai.server.repository;

import com.neoyokai.server.entity.Ronin;
import org.springframework.data.jpa.repository.JpaRepository;
import java.util.List;

public interface RoninRepository extends JpaRepository<Ronin, Long> {

    // Найти всех персонажей, которые привязаны к конкретному ID аккаунта
    List<Ronin> findAllByAccountId(Long accountId);
}