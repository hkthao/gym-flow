// src/tests/setup.ts
import { config } from '@vue/test-utils'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { vi } from 'vitest'

// Mock ResizeObserver
const ResizeObserverMock = vi.fn(() => ({
  observe: vi.fn(),
  unobserve: vi.fn(),
  disconnect: vi.fn()
}))
vi.stubGlobal('ResizeObserver', ResizeObserverMock)

// Mock matchMedia
Object.defineProperty(window, 'matchMedia', {
  writable: true,
  value: vi.fn().mockImplementation((query) => ({
    matches: false,
    media: query,
    onchange: null,
    addListener: vi.fn(), // deprecated
    removeListener: vi.fn(), // deprecated
    addEventListener: vi.fn(),
    removeEventListener: vi.fn(),
    dispatchEvent: vi.fn()
  }))
})

// Mock visualViewport
Object.defineProperty(window, 'visualViewport', {
  writable: true,
  configurable: true,
  value: {
    width: 1920,
    height: 1080,
    scale: 1,
    addEventListener: vi.fn(),
    removeEventListener: vi.fn()
  }
})

const vuetify = createVuetify({
  components,
  directives
})

config.global.plugins.push(vuetify)
