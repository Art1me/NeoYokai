package com.neoyokai.server.repository;

import com.neoyokai.server.entity.Account;
import org.springframework.data.jpa.repository.JpaRepository;
import java.util.Optional;

// JpaRepository принимает два параметра: <Сам Класс Сущности, Тип данных его ID>
public interface AccountRepository extends JpaRepository<Account, Long> {

    // МАГИЯ SPRING: Мы просто пишем название метода по правилам английского языка.
    // Spring сам переведет это в SQL: SELECT * FROM accounts WHERE username = ?
    Optional<Account> findByUsername(String username);

    // SQL: SELECT count(*) FROM accounts WHERE username = ?
    boolean existsByUsername(String username);
}