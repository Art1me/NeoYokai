package com.neoyokai.server.controller;

import com.neoyokai.server.service.AccountService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController // Говорит Spring, что этот класс обрабатывает HTTP-запросы и возвращает JSON
@RequestMapping("/api/auth") // Базовый URL для всех эндпоинтов в этом классе: http://localhost:8080/api/auth/...
public class AuthController {

    private final AccountService accountService;

    public AuthController(AccountService accountService) {
        this.accountService = accountService;
    }

    // Вспомогательный класс для приема JSON-данных от Unity
    public static class AuthRequest {
        public String username;
        public String password;
    }

    // POST-запрос на регистрацию: http://localhost:8080/api/auth/register
    @PostMapping("/register")
    public ResponseEntity<String> register(@RequestBody AuthRequest request) {
        boolean success = accountService.register(request.username, request.password);
        if (success) {
            return ResponseEntity.ok("Регистрация успешна!");
        } else {
            return ResponseEntity.badRequest().body("Ошибка: Имя пользователя уже занято.");
        }
    }

    // POST-запрос на логин: http://localhost:8080/api/auth/login
    @PostMapping("/login")
    public ResponseEntity<String> login(@RequestBody AuthRequest request) {
        boolean success = accountService.login(request.username, request.password);
        if (success) {
            return ResponseEntity.ok("Вход выполнен успешно!");
        } else {
            return ResponseEntity.status(401).body("Ошибка: Неверный логин или пароль.");
        }
    }
}