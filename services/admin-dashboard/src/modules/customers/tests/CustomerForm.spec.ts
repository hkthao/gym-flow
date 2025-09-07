import { describe, it, expect, vi, beforeEach } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerForm from '../components/CustomerForm.vue'
import { nextTick } from 'vue'

describe('CustomerForm.vue', () => {
  let wrapper

  beforeEach(() => {
    wrapper = mount(CustomerForm, {
      props: {
        visible: true,
        customer: {
          fullName: 'John Doe',
          phone: '123',
          email: 'test@test.com',
          gender: 'Male',
          address: '123 St'
        }
      },
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn,
          }),
        ],
        stubs: {
          'el-dialog': false,
          'el-form': false,
          'el-form-item': false,
          'el-input': false,
          'el-select': false,
          'el-option': false,
          'el-button': false,
        }
      },
      attachTo: document.body
    })
  })

  it('renders form with initial data', () => {
    const input = wrapper.find('input[type="text"]')
    expect((input.element as HTMLInputElement).value).toBe('John Doe')
  })

  it('updates form data on input', async () => {
    const input = wrapper.find('input[type="text"]')
    await input.setValue('Jane Doe')
    expect(wrapper.vm.form.fullName).toBe('Jane Doe')
  })

  it('emits update:visible when cancel button is clicked', async () => {
    const cancelButton = wrapper.findAll('.el-button').find(b => b.text() === 'Cancel')
    await cancelButton.trigger('click')
    expect(wrapper.emitted('update:visible')[0][0]).toBe(false)
  })

  it('closes the dialog on confirm', async () => {
    const confirmButton = wrapper.findAll('.el-button').find(b => b.text() === 'Confirm')
    await confirmButton.trigger('click')
    expect(wrapper.emitted('update:visible')[0][0]).toBe(false)
  })
})
