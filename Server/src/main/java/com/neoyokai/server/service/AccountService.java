package com.neoyokai.server.service;

import com.neoyokai.server.entity.Account;
import com.neoyokai.server.repository.AccountRepository;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service // Говорит Spring, что это компонент бизнес-логики, которым нужно управлять
public class AccountService {

    private final AccountRepository accountRepository;

    // Внедрение зависимостей через конструктор (стандарт хорошего тона)
    public AccountService(AccountRepository accountRepository) {
        this.accountRepository = accountRepository;
    }

    // Регистрация нового игрока
    public boolean register(String username, String rawPassword) {
        if (accountRepository.existsByUsername(username)) {
            return false; // Имя уже занято
        }

        Account account = new Account();
        account.setUsername(username);
        // В реальном проекте здесь должен быть BCrypt, но для MVP пока сохраняем "в лоб"
        account.setPasswordHash(rawPassword);

        accountRepository.save(account);
        return true;
    }

    // Авторизация
    public boolean login(String username, String rawPassword) {
        Optional<Account> accountOpt = accountRepository.findByUsername(username);
        if (accountOpt.isEmpty()) {
            return false; // Аккаунт не найден
        }

        Account account = accountOpt.get();
        // Сравниваем пароль
        return account.getPasswordHash().equals(rawPassword);
    }
}